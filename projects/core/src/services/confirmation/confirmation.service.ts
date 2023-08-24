import { inject, Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ConfirmationConfig } from './confirmation.types';
import { merge } from 'lodash-es';
import { ConfirmationDialogComponent } from './dialog/dialog.component';

@Injectable({ providedIn: 'root' })
export class ConfirmationService {
	private _matDialog: MatDialog = inject(MatDialog);
	private _defaultConfig: ConfirmationConfig = {
		title: 'Confirm action',
		message: 'Are you sure you want to confirm this action?',
		icon: {
			show: true,
			name: 'heroicons_outline:exclamation-triangle',
			color: 'warn',
		},
		actions: {
			confirm: {
				show: true,
				label: 'Confirm',
				color: 'warn',
			},
			cancel: {
				show: true,
				label: 'Cancel',
			},
		},
		dismissible: false,
	};

	/**
	 * Constructor
	 */
	constructor() {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

	open(config: ConfirmationConfig = {}): MatDialogRef<ConfirmationDialogComponent> {
		// Merge the user config with the default config
		const userConfig = merge({}, this._defaultConfig, config);

		// Open the dialog
		return this._matDialog.open(ConfirmationDialogComponent, {
			autoFocus: false,
			disableClose: !userConfig.dismissible,
			data: userConfig,
			panelClass: 'ontrial-confirmation-dialog-panel',
		});
	}
}
