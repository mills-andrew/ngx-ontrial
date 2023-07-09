import { NgClass } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnDestroy, OnInit } from '@angular/core';
import { OntrialHorizontalNavigationComponent } from '../../../horizontal/horizontal.component';
import { OntrialNavigationService } from '../../../../services/navigation.service';
import { Subject, takeUntil } from 'rxjs';
import { NavigationItem } from '../../../../common';

@Component({
	selector: 'ontrial-horizontal-navigation-spacer-item',
	templateUrl: './spacer.component.html',
	changeDetection: ChangeDetectionStrategy.OnPush,
	standalone: true,
	imports: [NgClass],
})
export class OntrialHorizontalNavigationSpacerItemComponent implements OnInit, OnDestroy {
	@Input() item!: NavigationItem;
	@Input() name!: string;

	private _ontrialHorizontalNavigationComponent!: OntrialHorizontalNavigationComponent;
	private _unsubscribeAll: Subject<any> = new Subject<any>();

	/**
	 * Constructor
	 */
	constructor(
		private _changeDetectorRef: ChangeDetectorRef,
		private _ontrialNavigationService: OntrialNavigationService,
	) {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Lifecycle hooks
	// -----------------------------------------------------------------------------------------------------

	/**
	 * On init
	 */
	ngOnInit(): void {
		// Get the parent navigation component
		this._ontrialHorizontalNavigationComponent = this._ontrialNavigationService.getComponent(this.name);

		// Subscribe to onRefreshed on the navigation component
		this._ontrialHorizontalNavigationComponent!.onRefreshed.pipe(
			takeUntil(this._unsubscribeAll),
		).subscribe(() => {
			// Mark for check
			this._changeDetectorRef.markForCheck();
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
}
