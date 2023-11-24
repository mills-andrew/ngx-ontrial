import { Inject, Injectable } from '@angular/core';
import { ONTRIAL_CONFIG } from './config.constants';
import { merge } from 'lodash-es';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class ConfigService {
	private _config: BehaviorSubject<any>;

	/**
	 * Constructor
	 */
	constructor(@Inject(ONTRIAL_CONFIG) config: any,
		private http: HttpClient) {
		// Private
		this._config = new BehaviorSubject(config);
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Accessors
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Setter & getter for config
	 */
	set config(value: any) {
		// Merge the new config over to the current config
		const config = merge({}, this._config.getValue(), value);

		// Execute the observable
		this._config.next(config);
	}

	get config(): any {
		return this._config.getValue();
	}

	// eslint-disable-next-line @typescript-eslint/member-ordering
	get config$(): Observable<any> {
		return this._config.asObservable();
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

	load(url: string): Promise<any> {
		return this.http.get(url).toPromise().then(data => {
			// Set the fetched data to _config BehaviorSubject
			this.config = data;
			return data;
		});
	}

	/**
	 * Resets the config to the default
	 */
	reset(): void {
		// Set the config
		this._config.next(this.config);
	}
}
