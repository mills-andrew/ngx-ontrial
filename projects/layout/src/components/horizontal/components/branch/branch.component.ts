import { BooleanInput } from '@angular/cdk/coercion';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, forwardRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatMenu } from '@angular/material/menu';
import { HorizontalNavigationComponent } from '../../../horizontal/horizontal.component';
import { NavigationEntityService } from '../../../../common/navigation-entity.service';
import { Subject, takeUntil } from 'rxjs';
import { NavigationEntity } from '../../../../common';

@Component({
	selector: 'ontrial-horizontal-navigation-branch-item',
	templateUrl: './branch.component.html',
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class HorizontalNavigationBranchItemComponent implements OnInit, OnDestroy {
	/* eslint-disable @typescript-eslint/naming-convention */
	static ngAcceptInputType_child: BooleanInput;
	/* eslint-enable @typescript-eslint/naming-convention */

	@Input() child: boolean = false;
	@Input() item!: NavigationEntity;
	@Input() name!: string;
	@ViewChild('matMenu', { static: true }) matMenu!: MatMenu;

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
		this._ontrialHorizontalNavigationComponent = this._ontrialNavigationService.getComponent(this.name!);

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

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Trigger the change detection
	 */
	triggerChangeDetection(): void {
		// Mark for check
		this._changeDetectorRef.markForCheck();
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
