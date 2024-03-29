import { NgClass, NgIf, NgTemplateOutlet } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnDestroy, OnInit } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatTooltipModule } from '@angular/material/tooltip';
import { IsActiveMatchOptions, RouterLink, RouterLinkActive } from '@angular/router';
import { HorizontalNavigationComponent } from '../../../horizontal/horizontal.component';
import { UtilsService } from '@ngx-ontrial/core';
import { Subject, takeUntil } from 'rxjs';
import { INavigationEntity } from '../../../../modules/navigation.types';
import { NavigationEntityService } from '../../../../modules/navigation-entity.service';

@Component({
	selector: 'ontrial-horizontal-navigation-basic-item',
	templateUrl: './basic.component.html',
	changeDetection: ChangeDetectionStrategy.OnPush,
	standalone: true,
	imports: [NgClass, NgIf, RouterLink, RouterLinkActive, MatTooltipModule, NgTemplateOutlet, MatMenuModule, MatIconModule],
})
export class HorizontalNavigationBasicItemComponent implements OnInit, OnDestroy {
	@Input() item!: INavigationEntity;
	@Input() name!: string;

	isActiveMatchOptions: IsActiveMatchOptions;
	private _ontrialHorizontalNavigationComponent!: HorizontalNavigationComponent;
	private _unsubscribeAll: Subject<any> = new Subject<any>();

	/**
	 * Constructor
	 */
	constructor(
		private _changeDetectorRef: ChangeDetectorRef,
		private _ontrialNavigationService: NavigationEntityService,
		private _UtilsService: UtilsService,
	) {
		// Set the equivalent of {exact: false} as default for active match options.
		// We are not assigning the item.isActiveMatchOptions directly to the
		// [routerLinkActiveOptions] because if it's "undefined" initially, the router
		// will throw an error and stop working.
		this.isActiveMatchOptions = this._UtilsService.subsetMatchOptions;
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Lifecycle hooks
	// -----------------------------------------------------------------------------------------------------

	/**
	 * On init
	 */
	ngOnInit(): void {
		// Set the "isActiveMatchOptions" either from item's
		// "isActiveMatchOptions" or the equivalent form of
		// item's "exactMatch" option
		this.isActiveMatchOptions =
			this.item!.isActiveMatchOptions ?? this.item!.exactMatch
				? this._UtilsService.exactMatchOptions
				: this._UtilsService.subsetMatchOptions;

		// Get the parent navigation component
		this._ontrialHorizontalNavigationComponent = this._ontrialNavigationService.getComponent(this.name!);

		// Mark for check
		this._changeDetectorRef.markForCheck();

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
