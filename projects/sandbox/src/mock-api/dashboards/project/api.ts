import { Injectable } from '@angular/core';
import { project as projectData } from './data';
import { cloneDeep } from 'lodash-es';
import { MockApiService } from '@ngx-ontrial/auth';

@Injectable({ providedIn: 'root' })
export class ProjectMockApi {
	private _project: any = projectData;

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
			.onGet('api/dashboards/project')
			.reply(() => [200, cloneDeep(this._project)]);
	}
}
