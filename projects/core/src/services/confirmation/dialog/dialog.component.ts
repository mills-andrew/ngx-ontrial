import { NgClass, NgIf } from '@angular/common';
import { Component, Inject, ViewEncapsulation } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { ConfirmationConfig } from '../confirmation.types';

@Component({
	selector: 'confirmation-dialog',
	templateUrl: './dialog.component.html',
	styleUrls: ['./dialog.component.scss'],
	encapsulation: ViewEncapsulation.None,
	standalone: true,
	imports: [NgIf, MatButtonModule, MatDialogModule, MatIconModule, NgClass],
})
export class ConfirmationDialogComponent {
	/**
	 * Constructor
	 */
	constructor(@Inject(MAT_DIALOG_DATA) public data: ConfirmationConfig) {

	}
}
