import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject, tap } from 'rxjs';
import { INavigation } from './navigation.interface';

@Injectable({ providedIn: 'root' })
export class NavigationService {
	private _navigation: ReplaySubject<INavigation> = new ReplaySubject<INavigation>(1);

	/**
	 * Constructor
	 */
	constructor(private _httpClient: HttpClient) {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Accessors
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Getter for navigation
	 */
	get navigation$(): Observable<INavigation> {
		return this._navigation.asObservable();
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Get all navigation data
	 */
	get(): Observable<INavigation> {
		return this._httpClient.get<INavigation>('api/common/navigation').pipe(
			tap((navigation) => {
				this._navigation.next(navigation);
			}),
		);
	}
}
