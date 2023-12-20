import { NgFor, NgIf } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDrawer, MatSidenavModule } from '@angular/material/sidenav';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ActivatedRoute, Router, RouterLink, RouterOutlet } from '@angular/router';
import { FileManagerService } from '../file-manager.service';
import { Item, Items } from '../file-manager.types';
import { Subject, catchError, takeUntil } from 'rxjs';
import { MediaWatcherService, UtilsService } from '@ngx-ontrial/core';
import { FileUploadComponent } from '../file-upload/file-upload.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
	selector: 'file-manager-list',
	templateUrl: './list.component.html',
	encapsulation: ViewEncapsulation.None,
	changeDetection: ChangeDetectionStrategy.OnPush,
	standalone: true,
	imports: [FileUploadComponent, MatSidenavModule, RouterOutlet, NgIf, RouterLink, NgFor, MatButtonModule, MatIconModule, MatTooltipModule],
})
export class FileManagerListComponent implements OnInit, OnDestroy {
	// Parent component
	showFileUpload = false;

	@ViewChild('matDrawer', { static: true }) matDrawer!: MatDrawer;
	drawerMode!: 'side' | 'over';
	selectedItem!: Item;
	selectedFolder!: Item;
	items!: Items;
	private _unsubscribeAll: Subject<any> = new Subject<any>();

	/**
	 * Constructor
	 */
	constructor(
		private _utilsService: UtilsService,
		private _matDialog: MatDialog,
		private _activatedRoute: ActivatedRoute,
		private _changeDetectorRef: ChangeDetectorRef,
		private _router: Router,
		private _fileManagerService: FileManagerService,
		private _fuseMediaWatcherService: MediaWatcherService,
	) {
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Lifecycle hooks
	// -----------------------------------------------------------------------------------------------------

	/**
	 * On init
	 */
	ngOnInit(): void {
		// Get the items
		this._fileManagerService.items$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((items: Items | null) => {
				if (items === null) return;

				this.items = items;

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});

		// Get the item
		this._fileManagerService.file$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((item: Item | null) => {
				if (item === null) return;

				this.selectedItem = item;

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});

		// Subscribe to media query change
		this._fuseMediaWatcherService.onMediaQueryChange$('(min-width: 1440px)')
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((state) => {
				// Calculate the drawer mode
				this.drawerMode = state.matches ? 'side' : 'over';

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

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

	/**
	 * On backdrop clicked
	 */
	onBackdropClicked(): void {
		// Go back to the list
		this._router.navigate(['./'], { relativeTo: this._activatedRoute });

		// Mark for check
		this._changeDetectorRef.markForCheck();
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

	onFileSelected(event: any) {
		let folder: Item = this.items.path[this.items.path.length - 1];
		for (let file of event.target.files) {
			let _tmpFile: Item = {
				id: this._utilsService.randomId(),
				folderId: folder.id,
				name: file.name,
				createdBy: 'Andrew Mills',
				createdAt: 'June 02, 2020',
				modifiedAt: 'June 02, 2020',
				size: file.size,
				type: file.type,
				contents: file.contents,
				description: 'string | null'
			}
			this.items.files.push(_tmpFile);
		}
	}

	addFiles(): void {
		let folder: Item = this.items.path[this.items.path.length - 1] ??
		{
			name: "Root"
		}
		this._matDialog.open(FileUploadComponent, {
			data: {
				item: folder,
			},
		});
	}
}
