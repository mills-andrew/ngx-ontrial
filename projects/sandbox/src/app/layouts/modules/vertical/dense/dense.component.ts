import { NgIf } from '@angular/common';
import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { LoadingBarComponent } from '@ngx-ontrial/material';
import { Navigation } from '../../../common/';
import { OntrialVerticalNavigationComponent } from '../../../components/vertical/vertical.component';
import { OntrialNavigationService } from '../../../services/navigation.service';
import { MediaWatcherService } from '@ngx-ontrial/core';
import { Subject, takeUntil } from 'rxjs';

@Component({
	selector: 'dense-layout',
	templateUrl: './dense.component.html',
	encapsulation: ViewEncapsulation.None,
	standalone: true,
	imports: [LoadingBarComponent, OntrialVerticalNavigationComponent, MatButtonModule, MatIconModule, NgIf, RouterOutlet],
})
export class DenseLayoutComponent implements OnInit, OnDestroy {
	isScreenSmall!: boolean;
	navigation!: Navigation;
	navigationAppearance: 'default' | 'dense' = 'dense';
	private _unsubscribeAll: Subject<any> = new Subject<any>();

	/**
	 * Constructor
	 */
	constructor(
		private _activatedRoute: ActivatedRoute,
		private _router: Router,
		private _navigationService: OntrialNavigationService,
		private _MediaWatcherService: MediaWatcherService,
		private _ontrialNavigationService: OntrialNavigationService,
	) {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Accessors
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Getter for current year
	 */
	get currentYear(): number {
		return new Date().getFullYear();
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Lifecycle hooks
	// -----------------------------------------------------------------------------------------------------

	/**
	 * On init
	 */
	ngOnInit(): void {
		// Subscribe to navigation data
		// this._navigationService.navigation$
		// 	.pipe(takeUntil(this._unsubscribeAll))
		// 	.subscribe((navigation: Navigation<NavigationItem>) => {
		// 		this.navigation = navigation;
		// 	});

		// Subscribe to media changes
		this._MediaWatcherService.onMediaChange$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe(({ matchingAliases }) => {
				// Check if the screen is small
				this.isScreenSmall = !matchingAliases.includes('md');

				// Change the navigation appearance
				this.navigationAppearance = this.isScreenSmall ? 'default' : 'dense';
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
	 * Toggle navigation
	 *
	 * @param name
	 */
	toggleNavigation(name: string): void {
		// Get the navigation
		const navigation = this._ontrialNavigationService.getComponent<OntrialVerticalNavigationComponent>(name);

		if (navigation) {
			// Toggle the opened status
			navigation.toggle();
		}
	}

	/**
	 * Toggle the navigation appearance
	 */
	toggleNavigationAppearance(): void {
		this.navigationAppearance = (this.navigationAppearance === 'default' ? 'dense' : 'default');
	}
}
