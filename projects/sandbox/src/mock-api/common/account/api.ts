import { Injectable } from '@angular/core';
import { MockApiService } from '@ngx-ontrial/auth';
import { account as accountData } from './data';
import { assign, cloneDeep } from 'lodash-es';

@Injectable({ providedIn: 'root' })
export class AccountMockApi {
	private _account: any = accountData;

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
		// @ Account - GET
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onGet('api/common/account')
			.reply(() => [200, cloneDeep(this._account)]);

		// -----------------------------------------------------------------------------------------------------
		// @ Account - PATCH
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onPatch('api/common/account')
			.reply(({ request }) => {
				// Get the account mock-api
				const account = cloneDeep(request.body.account);

				// Update the account mock-api
				this._account = assign({}, this._account, account);

				// Return the response
				return [200, cloneDeep(this._account)];
			});
	}
}
