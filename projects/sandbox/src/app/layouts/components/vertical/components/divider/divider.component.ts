import { NgClass } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnDestroy, OnInit } from '@angular/core';
import { OntrialNavigationService } from '../../../../services/navigation.service';
import { NavigationItem } from '../../../../common';
import { OntrialVerticalNavigationComponent } from '../../../vertical/vertical.component';
import { Subject, takeUntil } from 'rxjs';

@Component({
	selector: 'ontrial-vertical-navigation-divider-item',
	templateUrl: './divider.component.html',
	changeDetection: ChangeDetectionStrategy.OnPush,
	standalone: true,
	imports: [NgClass],
})
export class OntrialVerticalNavigationDividerItemComponent implements OnInit, OnDestroy {
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
}
