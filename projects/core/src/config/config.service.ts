import { Injectable } from '@angular/core';
import { merge } from 'lodash-es';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class ConfigService {
	private _config: BehaviorSubject<any>;

	/**
	 * Constructor
	 */
	constructor(private http: HttpClient) {
		this._config = new BehaviorSubject({});
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Accessors
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Setter for config
	 */
	set config(value: any) {
		// Merge the new config over to the current config
		const config = merge({}, this._config.getValue(), value);

		// Execute the observable
		this._config.next(config);
	}

	/**
	 * getter for config
	 */
	get config(): any {
		return this._config.getValue();
	}

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
