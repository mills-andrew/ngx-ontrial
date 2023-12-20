import { DatePipe, NgClass, NgFor, NgIf } from '@angular/common';
import { ChangeDetectionStrategy, Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { ScrumboardCardDetailsComponent } from '../../scrumboard/card/details/details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { TextFieldModule } from '@angular/cdk/text-field';
import { MatTooltipModule } from '@angular/material/tooltip';
import { Item } from '../file-manager.types';
import { FileManagerService } from '../file-manager.service';
import { Subject } from 'rxjs';

@Component({
	selector: 'app-file-upload',
	templateUrl: './file-upload.component.html',
	encapsulation: ViewEncapsulation.None,
	changeDetection: ChangeDetectionStrategy.OnPush,
	standalone: true,
	imports: [MatButtonModule, MatTooltipModule, MatIconModule, FormsModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, TextFieldModule, NgClass, NgIf, MatDatepickerModule, NgFor, MatCheckboxModule, DatePipe],
})
export class FileUploadComponent implements OnInit {
	files: File[] = [];
	showModal: boolean = true;
	private _unsubscribeAll: Subject<any> = new Subject<any>();

	currentFolder: Item | null = null;

	constructor(
		@Inject(MAT_DIALOG_DATA) private _data: { item: Item },
		private _fileManagerService: FileManagerService,
		public matDialogRef: MatDialogRef<ScrumboardCardDetailsComponent>) {
		this.currentFolder = this._data.item!;

	}

	ngOnInit(): void {
	}



	removeFile(index: number) {
		this.files.splice(index, 1);
	}

	uploadFiles() {
		// Implement the logic to upload files to the server
		// Show progress bar during upload
	}


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
