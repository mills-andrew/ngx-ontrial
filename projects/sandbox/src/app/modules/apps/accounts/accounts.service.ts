import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Account, Country, Tag } from './accounts.types';
import { BehaviorSubject, filter, map, Observable, of, switchMap, take, tap, throwError } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AccountsService {
	// Private
	private _account: BehaviorSubject<Account | null> = new BehaviorSubject<Account | null>(null);
	private _accounts: BehaviorSubject<Account[] | null> = new BehaviorSubject<Account[] | null>(null);
	private _countries: BehaviorSubject<Country[] | null> = new BehaviorSubject<Country[] | null>(null);
	private _tags: BehaviorSubject<Tag[] | null> = new BehaviorSubject<Tag[] | null>(null);

	/**
	 * Constructor
	 */
	constructor(private _httpClient: HttpClient) {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Accessors
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Getter for account
	 */
	get account$(): Observable<Account | null> {
		return this._account.asObservable();
	}

	/**
	 * Getter for accounts
	 */
	get accounts$(): Observable<Account[] | null> {
		return this._accounts.asObservable();
	}

	/**
	 * Getter for countries
	 */
	get countries$(): Observable<Country[] | null> {
		return this._countries.asObservable();
	}

	/**
	 * Getter for tags
	 */
	get tags$(): Observable<Tag[] | null> {
		return this._tags.asObservable();
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Get accounts
	 */
	getAccounts(): Observable<Account[]> {
		return this._httpClient.get<Account[]>('api/apps/accounts/all').pipe(
			tap((accounts) => {
				this._accounts.next(accounts);
			}),
		);
	}

	/**
	 * Search accounts with given query
	 *
	 * @param query
	 */
	searchAccounts(query: string): Observable<Account[]> {
		return this._httpClient.get<Account[]>('api/apps/accounts/search', {
			params: { query },
		}).pipe(
			tap((accounts) => {
				this._accounts.next(accounts);
			}),
		);
	}

	/**
	 * Get account by id
	 */
	getAccountById(id: string): Observable<Account> {
		return this._accounts.pipe(
			take(1),
			map((accounts) => {
				// Find the account
				const account = accounts!.find(item => item.id === id) || null;

				// Update the account
				this._account.next(account);

				// Return the account
				return account;
			}),
			switchMap((account) => {
				if (!account) {
					return throwError('Could not found account with id of ' + id + '!');
				}

				return of(account);
			}),
		);
	}

	/**
	 * Create account
	 */
	createAccount(): Observable<Account> {
		return this.accounts$.pipe(
			take(1),
			switchMap(accounts => this._httpClient.post<Account>('api/apps/accounts/account', {}).pipe(
				map((newAccount) => {
					// Update the accounts with the new account
					this._accounts.next([newAccount, ...accounts!]);

					// Return the new account
					return newAccount;
				}),
			)),
		);
	}

	/**
	 * Update account
	 *
	 * @param id
	 * @param account
	 */
	updateAccount(id: string, account: Account): Observable<Account> {
		return this.accounts$.pipe(
			take(1),
			switchMap(accounts => this._httpClient.patch<Account>('api/apps/accounts/account', {
				id,
				account,
			}).pipe(
				map((updatedAccount) => {
					// Find the index of the updated account
					const index = accounts!.findIndex(item => item.id === id);

					// Update the account
					accounts![index] = updatedAccount;

					// Update the accounts
					this._accounts.next(accounts);

					// Return the updated account
					return updatedAccount;
				}),
				switchMap(updatedAccount => this.account$.pipe(
					take(1),
					filter((item): item is Account => !!item && item.id === id), // Type assertion
					tap(() => {
						// Update the account if it's selected
						this._account.next(updatedAccount);
					}),
				)),
			)),
		);
	}


	/**
	 * Delete the account
	 *
	 * @param id
	 */
	deleteAccount(id: string): Observable<boolean> {
		return this.accounts$.pipe(
			take(1),
			switchMap(accounts => this._httpClient.delete<boolean>('api/apps/accounts/account', { params: { id } }).pipe(
				map((isDeleted) => {
					if (isDeleted) {
						// Find the index of the deleted account
						const index = accounts!.findIndex(item => item.id === id);

						// Delete the account
						accounts!.splice(index, 1);

						// Update the accounts
						this._accounts.next(accounts);

						// Return true indicating successful deletion
						return true;
					} else {
						// Return false indicating deletion failed
						return false;
					}
				}),
			)),
		);
	}


	/**
	 * Get countries
	 */
	getCountries(): Observable<Country[]> {
		return this._httpClient.get<Country[]>('api/apps/accounts/countries').pipe(
			tap((countries) => {
				this._countries.next(countries);
			}),
		);
	}

	/**
	 * Get tags
	 */
	getTags(): Observable<Tag[]> {
		return this._httpClient.get<Tag[]>('api/apps/accounts/tags').pipe(
			tap((tags) => {
				this._tags.next(tags);
			}),
		);
	}

	/**
	 * Create tag
	 *
	 * @param tag
	 */
	createTag(tag: Tag): Observable<Tag> {
		return this.tags$.pipe(
			take(1),
			switchMap(tags => this._httpClient.post<Tag>('api/apps/accounts/tag', { tag }).pipe(
				map((newTag) => {
					// Update the tags with the new tag
					this._tags.next([...tags!, newTag]);

					// Return new tag from observable
					return newTag;
				}),
			)),
		);
	}

	/**
	 * Update the tag
	 *
	 * @param id
	 * @param tag
	 */
	updateTag(id: string, tag: Tag): Observable<Tag> {
		return this.tags$.pipe(
			take(1),
			switchMap(tags => this._httpClient.patch<Tag>('api/apps/accounts/tag', {
				id,
				tag,
			}).pipe(
				map((updatedTag) => {
					// Find the index of the updated tag
					const index = tags!.findIndex(item => item.id === id);

					// Update the tag
					tags![index] = updatedTag;

					// Update the tags
					this._tags.next(tags);

					// Return the updated tag
					return updatedTag;
				}),
			)),
		);
	}

	/**
	 * Delete the tag
	 *
	 * @param id
	 */
	deleteTag(id: string): Observable<boolean> {
		return this.tags$.pipe(
			take(1),
			switchMap(tags => this._httpClient.delete<boolean>('api/apps/accounts/tag', { params: { id } }).pipe(
				switchMap(isDeleted => {
					if (!isDeleted) {
						return of(false); // Return false indicating deletion failed
					}

					// Find the index of the deleted tag
					const index = tags!.findIndex(item => item.id === id);

					// Delete the tag
					tags!.splice(index, 1);

					// Update the tags
					this._tags.next(tags);

					// Now, update the accounts
					return this.accounts$.pipe(
						take(1),
						map((accounts) => {
							// Iterate through the accounts
							accounts!.forEach((account) => {
								const tagIndex = account.tags.findIndex(tag => tag === id);

								// If the account has the tag, remove it
								if (tagIndex > -1) {
									account.tags.splice(tagIndex, 1);
								}
							});

							// Return true indicating successful deletion
							return true;
						}),
					);
				}),
			)),
		);
	}


	/**
	 * Update the avatar of the given account
	 *
	 * @param id
	 * @param avatar
	 */
	uploadAvatar(id: string, avatar: File): Observable<Account | null> {
		return this.accounts$.pipe(
			take(1),
			switchMap(accounts => this._httpClient.post<Account>('api/apps/accounts/avatar', {
				id,
				avatar,
			}, {
				headers: {
					'Content-Type': avatar.type,
				},
			}).pipe(
				map((updatedAccount) => {
					// Find the index of the updated account
					const index = accounts!.findIndex(item => item.id === id);

					// Update the account
					accounts![index] = updatedAccount;

					// Update the accounts
					this._accounts.next(accounts);

					// Return the updated account
					return updatedAccount;
				}),
			)),
			switchMap(updatedAccount => this.account$.pipe(
				take(1),
				filter((item): item is Account => !!item && item.id === id), // Type assertion
				tap(() => {
					// Update the account if it's selected
					this._account.next(updatedAccount);
				}),
			)),
		);
	}
}
