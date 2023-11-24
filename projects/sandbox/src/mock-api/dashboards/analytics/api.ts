import { Injectable } from '@angular/core';
import { MockApiService } from '@ngx-ontrial/auth';
import { analytics as analyticsData } from './data';
import { cloneDeep } from 'lodash-es';

@Injectable({ providedIn: 'root' })
export class AnalyticsMockApi {
	private _analytics: any = analyticsData;

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
			.onGet('api/dashboards/analytics')
			.reply(() => [200, cloneDeep(this._analytics)]);
	}
}
