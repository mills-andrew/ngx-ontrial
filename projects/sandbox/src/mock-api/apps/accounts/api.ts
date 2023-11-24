import { Injectable } from '@angular/core';
import { accounts as accountsData, countries as countriesData, tags as tagsData } from './data';
import { assign, cloneDeep } from 'lodash-es';
import { from, map } from 'rxjs';
import { MockApiService, MockApiUtils } from '@ngx-ontrial/auth';

@Injectable({ providedIn: 'root' })
export class AccountsMockApi {
	private _accounts: any[] = accountsData;
	private _countries: any[] = countriesData;
	private _tags: any[] = tagsData;

	/**
	 * Constructor
	 */
	constructor(private _mockApiService: MockApiService) {
		// Register Mock API handlers
		this.registerHandlers();
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Register Mock API handlers
	 */
	registerHandlers(): void {
		// -----------------------------------------------------------------------------------------------------
		// @ Accounts - GET
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onGet('api/apps/accounts/all')
			.reply(() => {
				// Clone the accounts
				const accounts = cloneDeep(this._accounts);

				// Sort the accounts by the name field by default
				accounts.sort((a, b) => a.name.localeCompare(b.name));

				// Return the response
				return [200, accounts];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ Accounts Search - GET
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onGet('api/apps/accounts/search')
			.reply(({ request }) => {
				// Get the search query
				const query = request.params.get('query');

				// Clone the accounts
				let accounts = cloneDeep(this._accounts);

				// If the query exists...
				if (query) {
					// Filter the accounts
					accounts = accounts.filter(account => account.name && account.name.toLowerCase().includes(query.toLowerCase()));
				}

				// Sort the accounts by the name field by default
				accounts.sort((a, b) => a.name.localeCompare(b.name));

				// Return the response
				return [200, accounts];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ Account - GET
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onGet('api/apps/accounts/account')
			.reply(({ request }) => {
				// Get the id from the params
				const id = request.params.get('id');

				// Clone the accounts
				const accounts = cloneDeep(this._accounts);

				// Find the account
				const account = accounts.find(item => item.id === id);

				// Return the response
				return [200, account];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ Account - POST
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onPost('api/apps/accounts/account')
			.reply(() => {
				// Generate a new account
				const newAccount = {
					id: MockApiUtils.guid(),
					avatar: null,
					name: 'New Account',
					emails: [],
					phoneNumbers: [],
					job: {
						title: '',
						company: '',
					},
					birthday: null,
					address: null,
					notes: null,
					tags: [],
				};

				// Unshift the new account
				this._accounts.unshift(newAccount);

				// Return the response
				return [200, newAccount];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ Account - PATCH
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onPatch('api/apps/accounts/account')
			.reply(({ request }) => {
				// Get the id and account
				const id = request.body.id;
				const account = cloneDeep(request.body.account);

				// Prepare the updated account
				let updatedAccount = null;

				// Find the account and update it
				this._accounts.forEach((item, index, accounts) => {
					if (item.id === id) {
						// Update the account
						accounts[index] = assign({}, accounts[index], account);

						// Store the updated account
						updatedAccount = accounts[index];
					}
				});

				// Return the response
				return [200, updatedAccount];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ Account - DELETE
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onDelete('api/apps/accounts/account')
			.reply(({ request }) => {
				// Get the id
				const id = request.params.get('id');

				// Find the account and delete it
				this._accounts.forEach((item, index) => {
					if (item.id === id) {
						this._accounts.splice(index, 1);
					}
				});

				// Return the response
				return [200, true];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ Countries - GET
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onGet('api/apps/accounts/countries')
			.reply(() => [200, cloneDeep(this._countries)]);

		// -----------------------------------------------------------------------------------------------------
		// @ Tags - GET
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onGet('api/apps/accounts/tags')
			.reply(() => [200, cloneDeep(this._tags)]);

		// -----------------------------------------------------------------------------------------------------
		// @ Tags - POST
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onPost('api/apps/accounts/tag')
			.reply(({ request }) => {
				// Get the tag
				const newTag = cloneDeep(request.body.tag);

				// Generate a new GUID
				newTag.id = MockApiUtils.guid();

				// Unshift the new tag
				this._tags.unshift(newTag);

				// Return the response
				return [200, newTag];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ Tags - PATCH
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onPatch('api/apps/accounts/tag')
			.reply(({ request }) => {
				// Get the id and tag
				const id = request.body.id;
				const tag = cloneDeep(request.body.tag);

				// Prepare the updated tag
				let updatedTag = null;

				// Find the tag and update it
				this._tags.forEach((item, index, tags) => {
					if (item.id === id) {
						// Update the tag
						tags[index] = assign({}, tags[index], tag);

						// Store the updated tag
						updatedTag = tags[index];
					}
				});

				// Return the response
				return [200, updatedTag];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ Tag - DELETE
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onDelete('api/apps/accounts/tag')
			.reply(({ request }) => {
				// Get the id
				const id = request.params.get('id');

				// Find the tag and delete it
				this._tags.forEach((item, index) => {
					if (item.id === id) {
						this._tags.splice(index, 1);
					}
				});

				// Get the accounts that have the tag
				const accountsWithTag = this._accounts.filter(account => account.tags.indexOf(id) > -1);

				// Iterate through them and delete the tag
				accountsWithTag.forEach((account) => {
					account.tags.splice(account.tags.indexOf(id), 1);
				});

				// Return the response
				return [200, true];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ Avatar - POST
		// -----------------------------------------------------------------------------------------------------

		/**
		 * Read the given file as mock-api url
		 *
		 * @param file
		 */
		const readAsDataURL = (file: File): Promise<any> =>

			// Return a new promise
			new Promise((resolve, reject) => {
				// Create a new reader
				const reader = new FileReader();

				// Resolve the promise on success
				reader.onload = (): void => {
					resolve(reader.result);
				};

				// Reject the promise on error
				reader.onerror = (e): void => {
					reject(e);
				};

				// Read the file as the
				reader.readAsDataURL(file);
			})
			;

		this._mockApiService
			.onPost('api/apps/accounts/avatar')
			.reply(({ request }) => {
				// Get the id and avatar
				const id = request.body.id;
				const avatar = request.body.avatar;

				// Prepare the updated account
				let updatedAccount: any = null;

				// In a real world application, this would return the path
				// of the saved image file (from host, S3 bucket, etc.) but,
				// for the sake of the demo, we encode the image to base64
				// and return it as the new path of the uploaded image since
				// the src attribute of the img tag works with both image urls
				// and encoded images.
				return from(readAsDataURL(avatar)).pipe(
					map((path) => {
						// Find the account and update it
						this._accounts.forEach((item, index, accounts) => {
							if (item.id === id) {
								// Update the avatar
								accounts[index].avatar = path;

								// Store the updated account
								updatedAccount = accounts[index];
							}
						});

						// Return the response
						return [200, updatedAccount];
					}),
				);
			});
	}
}
