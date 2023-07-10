import { BooleanInput } from '@angular/cdk/coercion';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, forwardRef, Input, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { VerticalNavigationComponent } from '../../vertical.component';
import { NavigationEntityService } from '../../../../common/navigation-entity.service';
import { NavigationEntity } from '../../../../common';

@Component({
	selector: 'ontrial-vertical-navigation-group-item',
	templateUrl: './group.component.html',
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class VerticalNavigationGroupItemComponent implements OnInit, OnDestroy {
	/* eslint-disable @typescript-eslint/naming-convention */
	static ngAcceptInputType_autoCollapse: BooleanInput;
	/* eslint-enable @typescript-eslint/naming-convention */

	@Input() autoCollapse!: boolean;
	@Input() item!: NavigationEntity;
	@Input() name!: string;

	private _ontrialVerticalNavigationComponent!: VerticalNavigationComponent;
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
		this._ontrialVerticalNavigationComponent = this._ontrialNavigationService.getComponent(this.name!);

		// Subscribe to onRefreshed on the navigation component
		this._ontrialVerticalNavigationComponent!.onRefreshed.pipe(
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

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

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
