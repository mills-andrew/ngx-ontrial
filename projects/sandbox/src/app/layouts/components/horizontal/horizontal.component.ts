import { NgFor, NgIf } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnChanges, OnDestroy, OnInit, SimpleChanges, ViewEncapsulation } from '@angular/core';
import { ontrialAnimations } from '@ngx-ontrial/common';
import { OntrialNavigationService } from '../../services/navigation.service';
import { UtilsService } from '@ngx-ontrial/core';
import { ReplaySubject, Subject } from 'rxjs';
import { OntrialHorizontalNavigationBasicItemComponent } from './components/basic/basic.component';
import { OntrialHorizontalNavigationBranchItemComponent } from './components/branch/branch.component';
import { OntrialHorizontalNavigationSpacerItemComponent } from './components/spacer/spacer.component';
import { NavigationItem } from '../../common/navigation.types';

@Component({
	selector: 'ontrial-horizontal-navigation',
	templateUrl: './horizontal.component.html',
	styleUrls: ['./horizontal.component.scss'],
	animations: ontrialAnimations,
	encapsulation: ViewEncapsulation.None,
	changeDetection: ChangeDetectionStrategy.OnPush,
	exportAs: 'ontrialHorizontalNavigation',
	standalone: true,
	imports: [NgFor, NgIf, OntrialHorizontalNavigationBasicItemComponent, OntrialHorizontalNavigationBranchItemComponent, OntrialHorizontalNavigationSpacerItemComponent],
})
export class OntrialHorizontalNavigationComponent implements OnChanges, OnInit, OnDestroy {
	@Input() name: string = this._UtilsService.randomId();
	@Input() navigation!: NavigationItem[];

	onRefreshed: ReplaySubject<boolean> = new ReplaySubject<boolean>(1);
	private _unsubscribeAll: Subject<any> = new Subject<any>();

	/**
	 * Constructor
	 */
	constructor(
		private _changeDetectorRef: ChangeDetectorRef,
		private _ontrialNavigationService: OntrialNavigationService,
		private _UtilsService: UtilsService,
	) {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Lifecycle hooks
	// -----------------------------------------------------------------------------------------------------

	/**
	 * On changes
	 *
	 * @param changes
	 */
	ngOnChanges(changes: SimpleChanges): void {
		// Navigation
		if ('navigation' in changes) {
			// Mark for check
			this._changeDetectorRef.markForCheck();
		}
	}

	/**
	 * On init
	 */
	ngOnInit(): void {
		// Make sure the name input is not an empty string
		if (this.name === '') {
			this.name = this._UtilsService.randomId();
		}

		// Register the navigation component
		this._ontrialNavigationService.registerComponent(this.name, this);
	}

	/**
	 * On destroy
	 */
	ngOnDestroy(): void {
		// Deregister the navigation component from the registry
		this._ontrialNavigationService.deregisterComponent(this.name);

		// Unsubscribe from all subscriptions
		this._unsubscribeAll.next(null);
		this._unsubscribeAll.complete();
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Refresh the component to apply the changes
	 */
	refresh(): void {
		// Mark for check
		this._changeDetectorRef.markForCheck();

		// Execute the observable
		this.onRefreshed.next(true);
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
}
