import { Injectable } from '@angular/core';
import { finance as financeData } from './data';
import { cloneDeep } from 'lodash-es';
import { MockApiService } from '@ngx-ontrial/auth';

@Injectable({ providedIn: 'root' })
export class FinanceMockApi {
	private _finance: any = financeData;

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
		// @ Sales - GET
		// -----------------------------------------------------------------------------------------------------
		this._mockApiService
			.onGet('api/dashboards/finance')
			.reply(() => [200, cloneDeep(this._finance)]);
	}
}
