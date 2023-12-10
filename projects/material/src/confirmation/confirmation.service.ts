import { Injectable, inject } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { IConfirmationConfig } from './confirmation.types';
import { ConfirmationDialogComponent } from './dialog/dialog.component';

@Injectable({ providedIn: 'root' })
export class ConfirmationService {
	private _matDialog: MatDialog = inject(MatDialog);
	private _defaultConfig: IConfirmationConfig = {
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

	constructor(matDialog: MatDialog) {
		this._matDialog = matDialog;
	}

	open(config: IConfirmationConfig = {}): MatDialogRef<ConfirmationDialogComponent> {
		// Merge the user config with the default config
		const userConfig = { ...this._defaultConfig, ...config };

		// Open the dialog
		return this._matDialog.open(ConfirmationDialogComponent, {
			autoFocus: false,
			disableClose: !userConfig.dismissible,
			data: userConfig,
			panelClass: 'confirmation-dialog-panel',
		});
	}
}
