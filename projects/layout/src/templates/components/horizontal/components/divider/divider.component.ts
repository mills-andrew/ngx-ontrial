import { NgClass } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnDestroy, OnInit } from '@angular/core';
import { HorizontalNavigationComponent } from '../../../horizontal/horizontal.component';
import { Subject, takeUntil } from 'rxjs';
import { INavigationEntity } from '../../../../modules/navigation.types';
import { NavigationEntityService } from '../../../../modules/navigation-entity.service';

@Component({
	selector: 'ontrial-horizontal-navigation-divider-item',
	templateUrl: './divider.component.html',
	changeDetection: ChangeDetectionStrategy.OnPush,
	standalone: true,
	imports: [NgClass],
})
export class HorizontalNavigationDividerItemComponent implements OnInit, OnDestroy {
	@Input() item!: INavigationEntity;
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
		this._ontrialHorizontalNavigationComponent.onRefreshed.pipe(
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
