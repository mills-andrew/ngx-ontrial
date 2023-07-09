import { BooleanInput } from '@angular/cdk/coercion';
import { NgClass, NgFor, NgIf } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, forwardRef, Input, OnDestroy, OnInit } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { Subject, takeUntil } from 'rxjs';
import { OntrialVerticalNavigationBasicItemComponent } from '../basic/basic.component';
import { OntrialVerticalNavigationCollapsableItemComponent } from '../collapsable/collapsable.component';
import { OntrialVerticalNavigationDividerItemComponent } from '../divider/divider.component';
import { OntrialVerticalNavigationSpacerItemComponent } from '../spacer/spacer.component';
import { OntrialVerticalNavigationComponent } from '../../vertical.component';
import { OntrialNavigationService } from '../../../../services/navigation.service';
import { NavigationItem } from '../../../../common';

@Component({
	selector: 'ontrial-vertical-navigation-group-item',
	templateUrl: './group.component.html',
	changeDetection: ChangeDetectionStrategy.OnPush,
	standalone: true,
	imports: [NgClass, NgIf, MatIconModule, NgFor, OntrialVerticalNavigationBasicItemComponent, OntrialVerticalNavigationCollapsableItemComponent, OntrialVerticalNavigationDividerItemComponent, forwardRef(() => OntrialVerticalNavigationGroupItemComponent), OntrialVerticalNavigationSpacerItemComponent],
})
export class OntrialVerticalNavigationGroupItemComponent implements OnInit, OnDestroy {
	/* eslint-disable @typescript-eslint/naming-convention */
	static ngAcceptInputType_autoCollapse: BooleanInput;
	/* eslint-enable @typescript-eslint/naming-convention */

	@Input() autoCollapse!: boolean;
	@Input() item!: NavigationItem;
	@Input() name!: string;

	private _ontrialVerticalNavigationComponent!: OntrialVerticalNavigationComponent;
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
