import { BooleanInput, coerceBooleanProperty } from '@angular/cdk/coercion';
import { NgIf } from '@angular/common';
import { Component, HostBinding, Input, OnChanges, SimpleChanges, ViewEncapsulation } from '@angular/core';
import { ontrialAnimations } from '@ngx-ontrial/common';
import { CardFaceType } from './card.types';

@Component({
	selector: 'ontrial-card',
	templateUrl: './card.component.html',
	styleUrls: ['./card.component.scss'],
	encapsulation: ViewEncapsulation.None,
	animations: ontrialAnimations,
	exportAs: 'ontrialCard',
	standalone: true,
	imports: [NgIf],
})
export class CardComponent implements OnChanges {
	/* eslint-disable @typescript-eslint/naming-convention */
	static ngAcceptInputType_expanded: BooleanInput;
	static ngAcceptInputType_flippable: BooleanInput;
	/* eslint-enable @typescript-eslint/naming-convention */

	@Input() expanded: boolean = false;
	@Input() face: CardFaceType = 'front';
	@Input() flippable: boolean = false;

	/**
	 * Constructor
	 */
	constructor() {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Accessors
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Host binding for component classes
	 */
	@HostBinding('class') get classList(): any {
		/* eslint-disable @typescript-eslint/naming-convention */
		return {
			'ontrial-card-expanded': this.expanded,
			'ontrial-card-face-back': this.flippable && this.face === 'back',
			'ontrial-card-face-front': this.flippable && this.face === 'front',
			'ontrial-card-flippable': this.flippable,
		};
		/* eslint-enable @typescript-eslint/naming-convention */
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
		// Expanded
		if ('expanded' in changes) {
			// Coerce the value to a boolean
			this.expanded = coerceBooleanProperty(changes['expanded'].currentValue);
		}

		// Flippable
		if ('flippable' in changes) {
			// Coerce the value to a boolean
			this.flippable = coerceBooleanProperty(changes['flippable'].currentValue);
		}
	}
}
