import { NgClass, NgFor } from '@angular/common';
import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { Router } from '@angular/router';
import { ConfigService, IOntrialConfig, Scheme, Theme, Themes } from '@ngx-ontrial/core';
import { DrawerComponent } from '@ngx-ontrial/material';

import { Subject, takeUntil } from 'rxjs';

@Component({
	selector: 'settings',
	templateUrl: './settings.component.html',
	styles: [
		`
            settings {
                position: static;
                display: block;
                flex: none;
                width: auto;
            }

            @media (screen and min-width: 1280px) {

                empty-layout + settings .settings-cog {
                    right: 0 !important;
                }
            }
        `,
	],
	encapsulation: ViewEncapsulation.None,
	standalone: true,
	imports: [MatIconModule, DrawerComponent, MatButtonModule, NgFor, NgClass, MatTooltipModule],
})
export class SettingsComponent implements OnInit, OnDestroy {
	config!: IOntrialConfig;
	layout!: string;
	scheme!: 'dark' | 'light';
	theme!: string;
	themes!: Themes;
	private _unsubscribeAll: Subject<any> = new Subject<any>();

	/**
	 * Constructor
	 */
	constructor(
		private _router: Router,
		private _configService: ConfigService,
	) {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Lifecycle hooks
	// -----------------------------------------------------------------------------------------------------

	/**
	 * On init
	 */
	ngOnInit(): void {
		// Subscribe to config changes
		this._configService.config$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((config: IOntrialConfig) => {
				// Store the config
				this.config = config;
			});
	}

	/**
	 * On destroy
	 */
	ngOnDestroy(): void {
		// Unsubscribe from all subscriptions
		this._unsubscribeAll.next(null);
		this._unsubscribeAll.complete();
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Set the layout on the config
	 *
	 * @param layout
	 */
	setLayout(layout: string): void {
		// Clear the 'layout' query param to allow layout changes
		this._router.navigate([], {
			queryParams: {
				layout: null,
			},
			queryParamsHandling: 'merge',
		}).then(() => {
			// Set the config
			this._configService.config = { layout };
		});
	}

	/**
	 * Set the scheme on the config
	 *
	 * @param scheme
	 */
	setScheme(scheme: Scheme): void {
		this._configService.config = { scheme };
	}

	/**
	 * Set the theme on the config
	 *
	 * @param theme
	 */
	setTheme(theme: Theme): void {
		this._configService.config = { theme };
	}
}
