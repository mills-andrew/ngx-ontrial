import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUserModel, ICountryModel, ITagModel } from './users.types';
import { BehaviorSubject, filter, map, Observable, of, switchMap, take, tap, throwError } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UsersService {
	// Private
	private _user: BehaviorSubject<IUserModel | null> = new BehaviorSubject<IUserModel | null>(null);
	private _users: BehaviorSubject<IUserModel[] | null> = new BehaviorSubject<IUserModel[] | null>(null);
	private _countries: BehaviorSubject<ICountryModel[] | null> = new BehaviorSubject<ICountryModel[] | null>(null);
	private _tags: BehaviorSubject<ITagModel[] | null> = new BehaviorSubject<ITagModel[] | null>(null);

	/**
	 * Constructor
	 */
	constructor(private _httpClient: HttpClient) {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Accessors
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Getter for user
	 */
	get user$(): Observable<IUserModel | null> {
		return this._user.asObservable();
	}

	/**
	 * Getter for users
	 */
	get users$(): Observable<IUserModel[] | null> {
		return this._users.asObservable();
	}

	/**
	 * Getter for countries
	 */
	get countries$(): Observable<ICountryModel[] | null> {
		return this._countries.asObservable();
	}

	/**
	 * Getter for tags
	 */
	get tags$(): Observable<ITagModel[] | null> {
		return this._tags.asObservable();
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Get users
	 */
	getUsers(): Observable<IUserModel[]> {
		return this._httpClient.get<IUserModel[]>('api/apps/users/all').pipe(
			tap((users) => {
				this._users.next(users);
			}),
		);
	}

	/**
	 * Search users with given query
	 *
	 * @param query
	 */
	searchUsers(query: string): Observable<IUserModel[]> {
		return this._httpClient.get<IUserModel[]>('api/apps/users/search', {
			params: { query },
		}).pipe(
			tap((users) => {
				this._users.next(users);
			}),
		);
	}

	/**
	 * Get user by id
	 */
	getUserById(id: string): Observable<IUserModel> {
		return this._users.pipe(
			take(1),
			map((users) => {
				// Find the user
				const user = users!.find(item => item.id === id) || null;

				// Update the user
				this._user.next(user);

				// Return the user
				return user;
			}),
			switchMap((user) => {
				if (!user) {
					return throwError('Could not found user with id of ' + id + '!');
				}

				return of(user);
			}),
		);
	}

	/**
	 * Create user
	 */
	createUser(): Observable<IUserModel> {
		return this.users$.pipe(
			take(1),
			switchMap(users => this._httpClient.post<IUserModel>('api/apps/users/user', {}).pipe(
				map((newUser) => {
					// Update the users with the new user
					this._users.next([newUser, ...users!]);

					// Return the new user
					return newUser;
				}),
			)),
		);
	}

	/**
	 * Update user
	 *
	 * @param id
	 * @param user
	 */
	updateUser(id: string, user: IUserModel): Observable<IUserModel | null> {
		return this.users$.pipe(
			take(1),
			switchMap(users => this._httpClient.patch<IUserModel>('api/apps/users/user', {
				id,
				user,
			}).pipe(
				map((updatedUser) => {
					// Find the index of the updated user
					const index = users!.findIndex(item => item.id === id);

					// Update the user
					users![index] = updatedUser;

					// Update the users
					this._users.next(users);

					// Return the updated user
					return updatedUser;
				}),
				switchMap(updatedUser => this.user$.pipe(
					take(1),
					filter(item => !!item && item.id === id),
					tap(() => {
						// Update the user if it's selected
						this._user.next(updatedUser);

						// Return the updated user
						return updatedUser;
					}),
				)),
			)),
		);
	}

	/**
	 * Delete the user
	 *
	 * @param id
	 */
	deleteUser(id: string): Observable<boolean> {

		return this.users$.pipe(
			take(1),
			switchMap(users => this._httpClient.delete<boolean>('api/apps/users/user', { params: { id } }).pipe(
				map((isDeleted: boolean) => {
					// Find the index of the deleted user
					const index = users!.findIndex(item => item.id === id);

					// Delete the user
					users!.splice(index, 1);

					// Update the users
					this._users.next(users);

					// Return the deleted status
					return isDeleted;
				}),
			)),
		);
	}

	/**
	 * Get countries
	 */
	getCountries(): Observable<ICountryModel[]> {
		return this._httpClient.get<ICountryModel[]>('api/apps/users/countries').pipe(
			tap((countries) => {
				this._countries.next(countries);
			}),
		);
	}

	/**
	 * Get tags
	 */
	getTags(): Observable<ITagModel[]> {
		return this._httpClient.get<ITagModel[]>('api/apps/users/tags').pipe(
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
	createTag(tag: ITagModel): Observable<ITagModel> {
		return this.tags$.pipe(
			take(1),
			switchMap(tags => this._httpClient.post<ITagModel>('api/apps/users/tag', { tag }).pipe(
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
	updateTag(id: string, tag: ITagModel): Observable<ITagModel> {
		return this.tags$.pipe(
			take(1),
			switchMap(tags => this._httpClient.patch<ITagModel>('api/apps/users/tag', {
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
			switchMap(tags => this._httpClient.delete<boolean>('api/apps/users/tag', { params: { id } }).pipe(
				map((isDeleted: boolean) => {
					// Find the index of the deleted tag
					const index = tags!.findIndex(item => item.id === id);

					// Delete the tag
					tags!.splice(index, 1);

					// Update the tags
					this._tags.next(tags);

					// Return the deleted status
					return isDeleted;
				}),
				filter(isDeleted => isDeleted),
				switchMap(isDeleted => this.users$.pipe(
					take(1),
					map((users) => {
						// Iterate through the users
						users!.forEach((user) => {
							const tagIndex = user.tags.findIndex(tag => tag === id);

							// If the user has the tag, remove it
							if (tagIndex > -1) {
								user.tags.splice(tagIndex, 1);
							}
						});

						// Return the deleted status
						return isDeleted;
					}),
				)),
			)),
		);
	}

	/**
	 * Update the avatar of the given user
	 *
	 * @param id
	 * @param avatar
	 */
	uploadAvatar(id: string, avatar: File): Observable<IUserModel | null> {
		return this.users$.pipe(
			take(1),
			switchMap(users => this._httpClient.post<IUserModel>('api/apps/users/avatar', {
				id,
				avatar,
			}, {
				headers: {
					// eslint-disable-next-line @typescript-eslint/naming-convention
					'Content-Type': avatar.type,
				},
			}).pipe(
				map((updatedUser) => {
					// Find the index of the updated user
					const index = users!.findIndex(item => item.id === id);

					// Update the user
					users![index] = updatedUser;

					// Update the users
					this._users.next(users);

					// Return the updated user
					return updatedUser;
				}),
				switchMap(updatedUser => this.user$.pipe(
					take(1),
					filter(item => !!item && item.id === id),
					tap(() => {
						// Update the user if it's selected
						this._user.next(updatedUser);

						// Return the updated user
						return updatedUser;
					}),
				)),
			)),
		);
	}
}
