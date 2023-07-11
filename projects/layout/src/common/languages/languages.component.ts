import { NgFor, NgTemplateOutlet } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';

import { AvailableLangs, TranslocoService } from '@ngneat/transloco';
import { take } from 'rxjs';
import { NavigationEntityService } from '../../templates/modules';
import { VerticalNavigationComponent } from '../../templates/components/vertical/vertical.component';

@Component({
	selector: 'languages',
	templateUrl: './languages.component.html',
	encapsulation: ViewEncapsulation.None,
	changeDetection: ChangeDetectionStrategy.OnPush,
	exportAs: 'languages',
	standalone: true,
	imports: [MatButtonModule, MatMenuModule, NgTemplateOutlet, NgFor],
})
export class LanguagesComponent implements OnInit, OnDestroy {
	availableLangs!: { id: string, label: string }[];

	activeLang!: string;
	flagCodes: any;

	/**
	 * Constructor
	 */
	constructor(
		private _changeDetectorRef: ChangeDetectorRef,
		private _ontrialNavigationService: NavigationEntityService,
		@Inject(TranslocoService) private _translocoService: TranslocoService,
	) {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Lifecycle hooks
	// -----------------------------------------------------------------------------------------------------

	/**
	 * On init
	 */
	ngOnInit(): void {
		// Get the available languages from transloco
		const langs = this._translocoService.getAvailableLangs();

		// Check if langs is an array of strings
		if (typeof langs[0] === 'string') {
			// Convert string array to object array
			this.availableLangs = (langs as string[]).map((lang: string) => ({ id: lang, label: lang.toUpperCase() }));
		} else {
			// Assign it directly if it's already an object array
			this.availableLangs = langs as { id: string; label: string }[];
		}

		// Subscribe to language changes
		this._translocoService.langChanges$.subscribe((activeLang) => {
			// Get the active lang
			this.activeLang = activeLang;

			// Update the navigation
			this._updateNavigation(activeLang);
		});

		// Set the country iso codes for languages for flags
		this.flagCodes = {
			'en': 'us',
			'fr': 'fr',
		};
	}

	/**
	 * On destroy
	 */
	ngOnDestroy(): void {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Set the active lang
	 *
	 * @param lang
	 */
	setActiveLang(lang: string): void {
		// Set the active lang
		this._translocoService.setActiveLang(lang);
	}

	/**
	 * Track by function for ngFor loops
	 *
	 * @param index
	 * @param item
	 */
	trackByFn(index: number, item: any): any {
		return item.id || index;
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Private methods
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Update the navigation
	 *
	 * @param lang
	 * @private
	 */
	private _updateNavigation(lang: string): void {
		// For the demonstration purposes, we will only update the Dashboard names
		// from the navigation but you can do a full swap and change the entire
		// navigation data.
		//
		// You can import the data from a file or request it from your backend,
		// it's up to you.

		// Get the component -> navigation data -> item
		const navComponent = this._ontrialNavigationService.getComponent<VerticalNavigationComponent>('mainNavigation');

		// Return if the navigation component does not exist
		if (!navComponent) {
			return;
		}

		// Get the flat navigation data
		const navigation = navComponent.navigation;

		// Get the Project dashboard item and update its title
		const projectDashboardItem = this._ontrialNavigationService.getItem('dashboards.project', navigation);
		if (projectDashboardItem) {
			this._translocoService.selectTranslate('Project').pipe(take(1))
				.subscribe((translation: any) => {
					// Set the title
					projectDashboardItem.title = translation;

					// Refresh the navigation component
					navComponent.refresh();
				});
		}

		// Get the Analytics dashboard item and update its title
		const analyticsDashboardItem = this._ontrialNavigationService.getItem('dashboards.analytics', navigation);
		if (analyticsDashboardItem) {
			this._translocoService.selectTranslate('Analytics').pipe(take(1))
				.subscribe((translation: any) => {
					// Set the title
					analyticsDashboardItem.title = translation;

					// Refresh the navigation component
					navComponent.refresh();
				});
		}
	}
}
