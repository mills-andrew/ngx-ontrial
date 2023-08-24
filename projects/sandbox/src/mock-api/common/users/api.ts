import { Injectable } from '@angular/core';
import { MockApiService, MockApiUtils } from '@ngx-ontrial/auth';
import { users as usersData, countries as countriesData, tags as tagsData } from './data';
import { assign, cloneDeep } from 'lodash-es';
import { from, map } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UsersMockApi {
	private _users: any[] = usersData;
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
		// @ Users - GET
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onGet('api/apps/users/all')
			.reply(() => {
				// Clone the users
				const users = cloneDeep(this._users);

				// Sort the users by the name field by default
				users.sort((a, b) => a.name.localeCompare(b.name));

				// Return the response
				return [200, users];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ Users Search - GET
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onGet('api/apps/users/search')
			.reply(({ request }) => {
				// Get the search query
				const query = request.params.get('query');

				// Clone the users
				let users = cloneDeep(this._users);

				// If the query exists...
				if (query) {
					// Filter the users
					users = users.filter(user => user.name && user.name.toLowerCase().includes(query.toLowerCase()));
				}

				// Sort the users by the name field by default
				users.sort((a, b) => a.name.localeCompare(b.name));

				// Return the response
				return [200, users];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ User - GET
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onGet('api/apps/users/user')
			.reply(({ request }) => {
				// Get the id from the params
				const id = request.params.get('id');

				// Clone the users
				const users = cloneDeep(this._users);

				// Find the user
				const user = users.find(item => item.id === id);

				// Return the response
				return [200, user];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ User - POST
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onPost('api/apps/users/user')
			.reply(() => {
				// Generate a new user
				const newUser = {
					id: MockApiUtils.guid(),
					avatar: null,
					name: 'New User',
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

				// Unshift the new user
				this._users.unshift(newUser);

				// Return the response
				return [200, newUser];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ User - PATCH
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onPatch('api/apps/users/user')
			.reply(({ request }) => {
				// Get the id and user
				const id = request.body.id;
				const user = cloneDeep(request.body.user);

				// Prepare the updated user
				let updatedUser = null;

				// Find the user and update it
				this._users.forEach((item, index, users) => {
					if (item.id === id) {
						// Update the user
						users[index] = assign({}, users[index], user);

						// Store the updated user
						updatedUser = users[index];
					}
				});

				// Return the response
				return [200, updatedUser];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ User - DELETE
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onDelete('api/apps/users/user')
			.reply(({ request }) => {
				// Get the id
				const id = request.params.get('id');

				// Find the user and delete it
				this._users.forEach((item, index) => {
					if (item.id === id) {
						this._users.splice(index, 1);
					}
				});

				// Return the response
				return [200, true];
			});

		// -----------------------------------------------------------------------------------------------------
		// @ Countries - GET
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onGet('api/apps/users/countries')
			.reply(() => [200, cloneDeep(this._countries)]);

		// -----------------------------------------------------------------------------------------------------
		// @ Tags - GET
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onGet('api/apps/users/tags')
			.reply(() => [200, cloneDeep(this._tags)]);

		// -----------------------------------------------------------------------------------------------------
		// @ Tags - POST
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onPost('api/apps/users/tag')
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
			.onPatch('api/apps/users/tag')
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
			.onDelete('api/apps/users/tag')
			.reply(({ request }) => {
				// Get the id
				const id = request.params.get('id');

				// Find the tag and delete it
				this._tags.forEach((item, index) => {
					if (item.id === id) {
						this._tags.splice(index, 1);
					}
				});

				// Get the users that have the tag
				const usersWithTag = this._users.filter(user => user.tags.indexOf(id) > -1);

				// Iterate through them and delete the tag
				usersWithTag.forEach((user) => {
					user.tags.splice(user.tags.indexOf(id), 1);
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
			.onPost('api/apps/users/avatar')
			.reply(({ request }) => {
				// Get the id and avatar
				const id = request.body.id;
				const avatar = request.body.avatar;

				// Prepare the updated user
				let updatedUser: any = null;

				// In a real world application, this would return the path
				// of the saved image file (from host, S3 bucket, etc.) but,
				// for the sake of the demo, we encode the image to base64
				// and return it as the new path of the uploaded image since
				// the src attribute of the img tag works with both image urls
				// and encoded images.
				return from(readAsDataURL(avatar)).pipe(
					map((path) => {
						// Find the user and update it
						this._users.forEach((item, index, users) => {
							if (item.id === id) {
								// Update the avatar
								users[index].avatar = path;

								// Store the updated user
								updatedUser = users[index];
							}
						});

						// Return the response
						return [200, updatedUser];
					}),
				);
			});
	}
}
