import { AsyncPipe, DOCUMENT, I18nPluralPipe, NgClass, NgFor, NgIf } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormsModule, ReactiveFormsModule, UntypedFormControl } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatDrawer, MatSidenavModule } from '@angular/material/sidenav';
import { ActivatedRoute, Router, RouterLink, RouterOutlet } from '@angular/router';
import { filter, fromEvent, Observable, Subject, switchMap, takeUntil } from 'rxjs';
import { ICountryModel, IUserModel } from '../users.types';
import { MediaWatcherService } from '@ngx-ontrial/core';
import { UsersService } from '../users.service';

@Component({
	selector: 'users-list',
	templateUrl: './list.component.html',
	encapsulation: ViewEncapsulation.None,
	changeDetection: ChangeDetectionStrategy.OnPush,
	standalone: true,
	imports: [MatSidenavModule, RouterOutlet, NgIf, MatFormFieldModule, MatIconModule, MatInputModule, FormsModule, ReactiveFormsModule, MatButtonModule, NgFor, NgClass, RouterLink, AsyncPipe, I18nPluralPipe],
})
export class UsersListComponent implements OnInit, OnDestroy {
	@ViewChild('matDrawer', { static: true }) matDrawer!: MatDrawer;

	users$!: Observable<IUserModel[] | null>;

	usersCount: number = 0;
	usersTableColumns: string[] = ['name', 'email', 'phoneNumber', 'job'];
	countries: ICountryModel[] | null = null;
	drawerMode!: 'side' | 'over';
	searchInputControl: UntypedFormControl = new UntypedFormControl();
	selectedUser: IUserModel | null = null;
	private _unsubscribeAll: Subject<any> = new Subject<any>();

	/**
	 * Constructor
	 */
	constructor(
		private _activatedRoute: ActivatedRoute,
		private _changeDetectorRef: ChangeDetectorRef,
		private _usersService: UsersService,
		@Inject(DOCUMENT) private _document: any,
		private _router: Router,
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
		// Get the users
		this.users$ = this._usersService.users$;
		this._usersService.users$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((users: IUserModel[] | null) => {
				if (users) {
					// Update the counts
					this.usersCount = users.length;
				} else {
					// Reset the counts
					this.usersCount = 0;
				}

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});


		// Get the user
		this._usersService.user$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((user: IUserModel | null) => {
				// Update the selected user
				this.selectedUser = user;

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});

		// Get the countries
		this._usersService.countries$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((countries: ICountryModel[] | null) => {
				// Update the countries
				this.countries = countries;

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});

		// Subscribe to search input field value changes
		this.searchInputControl.valueChanges
			.pipe(
				takeUntil(this._unsubscribeAll),
				switchMap(query =>

					// Search
					this._usersService.searchUsers(query),
				),
			)
			.subscribe();

		// Subscribe to MatDrawer opened change
		this.matDrawer.openedChange.subscribe((opened) => {
			if (!opened) {
				// Remove the selected user when drawer closed
				this.selectedUser = null;

				// Mark for check
				this._changeDetectorRef.markForCheck();
			}
		});

		// Subscribe to media changes
		this._fuseMediaWatcherService.onMediaChange$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe(({ matchingAliases }) => {
				// Set the drawerMode if the given breakpoint is active
				if (matchingAliases.includes('lg')) {
					this.drawerMode = 'side';
				}
				else {
					this.drawerMode = 'over';
				}

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});

		// Listen for shortcuts
		fromEvent<KeyboardEvent>(this._document, 'keydown')
			.pipe(
				takeUntil(this._unsubscribeAll),
				filter<KeyboardEvent>(event =>
					(event.ctrlKey === true || event.metaKey) // Ctrl or Cmd
					&& (event.key === '/'), // '/'
				),
			)
			.subscribe(() => {
				this.createUser();
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
	 * Create user
	 */
	createUser(): void {
		// Create the user
		this._usersService.createUser().subscribe((newUser) => {
			// Go to the new user
			this._router.navigate(['./', newUser.id], { relativeTo: this._activatedRoute });

			// Mark for check
			this._changeDetectorRef.markForCheck();
		});
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
