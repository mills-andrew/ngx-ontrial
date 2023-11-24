import { AsyncPipe, DOCUMENT, I18nPluralPipe, NgClass, NgFor, NgIf } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormsModule, ReactiveFormsModule, UntypedFormControl } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatDrawer, MatSidenavModule } from '@angular/material/sidenav';
import { ActivatedRoute, Router, RouterLink, RouterOutlet } from '@angular/router';
import { AccountsService } from '../accounts.service';
import { Account, Country } from '../accounts.types';
import { filter, fromEvent, Observable, Subject, switchMap, takeUntil } from 'rxjs';
import { MediaWatcherService } from '@ngx-ontrial/core';

@Component({
	selector: 'accounts-list',
	templateUrl: './list.component.html',
	encapsulation: ViewEncapsulation.None,
	changeDetection: ChangeDetectionStrategy.OnPush,
	standalone: true,
	imports: [MatSidenavModule, RouterOutlet, NgIf, MatFormFieldModule, MatIconModule, MatInputModule, FormsModule, ReactiveFormsModule, MatButtonModule, NgFor, NgClass, RouterLink, AsyncPipe, I18nPluralPipe],
})
export class AccountsListComponent implements OnInit, OnDestroy {
	@ViewChild('matDrawer', { static: true }) matDrawer!: MatDrawer;

	accounts$: Observable<Account[] | null> | null = null;

	accountsCount: number = 0;
	accountsTableColumns: string[] = ['name', 'email', 'phoneNumber', 'job'];
	countries: Country[] | null = null;
	drawerMode!: 'side' | 'over';
	searchInputControl: UntypedFormControl = new UntypedFormControl();
	selectedAccount: Account | null = null;
	private _unsubscribeAll: Subject<any> = new Subject<any>();

	/**
	 * Constructor
	 */
	constructor(
		private _activatedRoute: ActivatedRoute,
		private _changeDetectorRef: ChangeDetectorRef,
		private _accountsService: AccountsService,
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
		// Get the accounts
		this.accounts$ = this._accountsService.accounts$;
		this._accountsService.accounts$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((accounts: Account[] | null) => {
				// Update the counts
				this.accountsCount = accounts!.length;

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});

		// Get the account
		this._accountsService.account$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((account: Account | null) => {
				// Update the selected account
				this.selectedAccount = account;

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});

		// Get the countries
		this._accountsService.countries$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((countries: Country[] | null) => {
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
					this._accountsService.searchAccounts(query),
				),
			)
			.subscribe();

		// Subscribe to MatDrawer opened change
		this.matDrawer.openedChange.subscribe((opened) => {
			if (!opened) {
				// Remove the selected account when drawer closed
				this.selectedAccount = null;

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
		fromEvent<KeyboardEvent>(this._document, 'keydown') // Specify the type here
			.pipe(
				takeUntil(this._unsubscribeAll),
				filter<KeyboardEvent>(event =>
					(event.ctrlKey === true || event.metaKey) && event.key === '/',
				),
			)
			.subscribe(() => {
				this.createAccount();
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
	 * Create account
	 */
	createAccount(): void {
		// Create the account
		this._accountsService.createAccount().subscribe((newAccount) => {
			// Go to the new account
			this._router.navigate(['./', newAccount.id], { relativeTo: this._activatedRoute });

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
