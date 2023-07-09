import { Component, ViewEncapsulation } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ontrialAnimations } from '@ngx-ontrial/common';

@Component({
	selector: 'auth-confirmation-required',
	templateUrl: './confirmation-required.component.html',
	encapsulation: ViewEncapsulation.None,
	animations: ontrialAnimations,
	standalone: true,
	imports: [RouterLink],
})
export class AuthConfirmationRequiredComponent {
	/**
	 * Constructor
	 */
	constructor() {
	}
}
