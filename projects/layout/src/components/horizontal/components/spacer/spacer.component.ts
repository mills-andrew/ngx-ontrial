import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnDestroy, OnInit } from '@angular/core';
import { HorizontalNavigationComponent } from '../../../horizontal/horizontal.component';
import { NavigationEntityService } from '../../../../common/navigation-entity.service';
import { Subject, takeUntil } from 'rxjs';
import { NavigationEntity } from '../../../../common';

@Component({
	selector: 'ontrial-horizontal-navigation-spacer-item',
	templateUrl: './spacer.component.html',
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class HorizontalNavigationSpacerItemComponent implements OnInit, OnDestroy {
	@Input() item!: NavigationEntity;
	@Input() name!: string;

	private _ontrialHorizontalNavigationComponent!: HorizontalNavigationComponent;
	private _unsubscribeAll: Subject<any> = new Subject<any>();

	/**
	 * Constructor
	 */
	constructor(
		private _changeDetectorRef: ChangeDetectorRef,
		private _ontrialNavigationService: NavigationEntityService,
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
