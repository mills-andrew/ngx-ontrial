import { TextFieldModule } from '@angular/cdk/text-field';
import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormsModule, ReactiveFormsModule, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@Component({
	selector: 'settings-account',
	templateUrl: './account.component.html',
	encapsulation: ViewEncapsulation.None,
	changeDetection: ChangeDetectionStrategy.OnPush,
	standalone: true,
	imports: [FormsModule, ReactiveFormsModule, MatFormFieldModule, MatIconModule, MatInputModule, TextFieldModule, MatSelectModule, MatOptionModule, MatButtonModule],
})
export class SettingsAccountComponent implements OnInit {
	accountForm!: UntypedFormGroup;

	/**
	 * Constructor
	 */
	constructor(
		private _formBuilder: UntypedFormBuilder,
	) {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Lifecycle hooks
	// -----------------------------------------------------------------------------------------------------

	/**
	 * On init
	 */
	ngOnInit(): void {
		// Create the form
		this.accountForm = this._formBuilder.group({
			name: ['Andrew Mills'],
			username: ['millsaj'],
			title: ['Senior Full Stack Developer'],
			company: ['Ontrial Studios'],
			about: ['Senior full stack developer. Loves to fish, game and code.'],
			email: ['Andrew.J.Denison@outlook.com', Validators.email],
			phone: ['(613) 770-4259'],
			country: ['canada'],
			language: ['english'],
		});
	}
}
