import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { TemplatePortal } from '@angular/cdk/portal';
import { TextFieldModule } from '@angular/cdk/text-field';
import { DatePipe, NgClass, NgFor, NgIf } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ElementRef, OnDestroy, OnInit, Renderer2, TemplateRef, ViewChild, ViewContainerRef, ViewEncapsulation } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormsModule, ReactiveFormsModule, UntypedFormArray, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatOptionModule, MatRippleModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDrawerToggleResult } from '@angular/material/sidenav';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { debounceTime, Subject, takeUntil } from 'rxjs';
import { AccountsListComponent } from '../list/list.component';
import { AccountsService } from '../accounts.service';
import { ConfirmationService, FindByKeyPipe } from '@ngx-ontrial/core';
import { Country, Tag, Account } from '../accounts.types';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
	selector: 'accounts-details',
	templateUrl: './details.component.html',
	encapsulation: ViewEncapsulation.None,
	changeDetection: ChangeDetectionStrategy.OnPush,
	standalone: true,
	providers: [ConfirmationService],
	imports: [NgIf, MatDialogModule, MatButtonModule, MatTooltipModule, RouterLink, MatIconModule, NgFor, FormsModule, ReactiveFormsModule, MatRippleModule, MatFormFieldModule, MatInputModule, MatCheckboxModule, NgClass, MatSelectModule, MatOptionModule, MatDatepickerModule, TextFieldModule, FindByKeyPipe, DatePipe],
})
export class AccountsDetailsComponent implements OnInit, OnDestroy {
	@ViewChild('avatarFileInput') private _avatarFileInput!: ElementRef;
	@ViewChild('tagsPanel') private _tagsPanel!: TemplateRef<any>;
	@ViewChild('tagsPanelOrigin') private _tagsPanelOrigin!: ElementRef;

	editMode: boolean = false;
	tags: Tag[] | null = null;
	tagsEditMode: boolean = false;
	filteredTags: Tag[] | null = null;
	account: Account | null = null;
	accountForm: UntypedFormGroup;
	accounts: Account[] | null = null;
	countries: Country[] | null = null;
	private _tagsPanelOverlayRef!: OverlayRef;
	private _unsubscribeAll: Subject<any> = new Subject<any>();

	/**
	 * Constructor
	 */
	constructor(
		private _fb: FormBuilder,
		private _activatedRoute: ActivatedRoute,
		private _changeDetectorRef: ChangeDetectorRef,
		private _accountsListComponent: AccountsListComponent,
		private _accountsService: AccountsService,
		private _formBuilder: UntypedFormBuilder,
		private _fuseConfirmationService: ConfirmationService,
		private _renderer2: Renderer2,
		private _router: Router,
		private _overlay: Overlay,
		private _viewContainerRef: ViewContainerRef,
	) {
		this.accountForm = this._fb.group({
			phoneNumbers: this._fb.array([]), // initialize phoneNumbers as a FormArray
		});
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Lifecycle hooks
	// -----------------------------------------------------------------------------------------------------

	/**
	 * On init
	 */
	ngOnInit(): void {
		// Open the drawer
		this._accountsListComponent.matDrawer.open();

		// Create the account form
		this.accountForm = this._formBuilder.group({
			id: [''],
			avatar: [null],
			name: ['', [Validators.required]],
			emails: this._formBuilder.array([]),
			phoneNumbers: this._formBuilder.array([]),
			title: [''],
			company: [''],
			birthday: [null],
			address: [null],
			notes: [null],
			tags: [[]],
		});

		// Get the accounts
		this._accountsService.accounts$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((accounts: Account[] | null) => {
				this.accounts = accounts;

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});

		// Get the account
		this._accountsService.account$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((account: Account | null) => {
				// Open the drawer in case it is closed
				this._accountsListComponent.matDrawer.open();

				// Get the account
				this.account = account;

				// Clear the emails and phoneNumbers form arrays
				(this.accountForm.get('emails') as UntypedFormArray).clear();
				(this.accountForm.get('phoneNumbers') as UntypedFormArray).clear();

				// Patch values to the form
				this.accountForm.patchValue(account!);

				// Setup the emails form array
				const emailFormGroups = [];

				if (account!.emails!.length > 0) {
					// Iterate through them
					account!.emails!.forEach((email) => {
						// Create an email form group
						emailFormGroups.push(
							this._formBuilder.group({
								email: [email.email],
								label: [email.label],
							}),
						);
					});
				}
				else {
					// Create an email form group
					emailFormGroups.push(
						this._formBuilder.group({
							email: [''],
							label: [''],
						}),
					);
				}

				// Add the email form groups to the emails form array
				emailFormGroups.forEach((emailFormGroup) => {
					(this.accountForm.get('emails') as UntypedFormArray).push(emailFormGroup);
				});

				// Setup the phone numbers form array
				const phoneNumbersFormGroups = [];

				if (account!.phoneNumbers!.length > 0) {
					// Iterate through them
					account!.phoneNumbers!.forEach((phoneNumber) => {
						// Create an email form group
						phoneNumbersFormGroups.push(
							this._formBuilder.group({
								country: [phoneNumber.country],
								phoneNumber: [phoneNumber.phoneNumber],
								label: [phoneNumber.label],
							}),
						);
					});
				}
				else {
					// Create a phone number form group
					phoneNumbersFormGroups.push(
						this._formBuilder.group({
							country: ['us'],
							phoneNumber: [''],
							label: [''],
						}),
					);
				}

				// Add the phone numbers form groups to the phone numbers form array
				phoneNumbersFormGroups.forEach((phoneNumbersFormGroup) => {
					(this.accountForm.get('phoneNumbers') as UntypedFormArray).push(phoneNumbersFormGroup);
				});

				// Toggle the edit mode off
				this.toggleEditMode(false);

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});

		// Get the country telephone codes
		this._accountsService.countries$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((codes: Country[] | null = null) => {
				this.countries = codes;

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});

		// Get the tags
		this._accountsService.tags$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((tags: Tag[] | null = null) => {
				this.tags = tags;
				this.filteredTags = tags;

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

		// Dispose the overlays if they are still on the DOM
		if (this._tagsPanelOverlayRef) {
			this._tagsPanelOverlayRef.dispose();
		}
	}

	// -----------------------------------------------------------------------------------------------------
	// @ Public methods
	// -----------------------------------------------------------------------------------------------------

	/**
	 * Close the drawer
	 */
	closeDrawer(): Promise<MatDrawerToggleResult> {
		return this._accountsListComponent.matDrawer.close();
	}

	/**
	 * Toggle edit mode
	 *
	 * @param editMode
	 */
	toggleEditMode(editMode: boolean | null = null): void {
		if (editMode === null) {
			this.editMode = !this.editMode;
		}
		else {
			this.editMode = editMode;
		}

		// Mark for check
		this._changeDetectorRef.markForCheck();
	}

	/**
	 * Update the account
	 */
	updateAccount(): void {
		// Get the account object
		const account = this.accountForm.getRawValue();

		// Go through the account object and clear empty values
		account.emails = account.emails.filter((email: { email: any; }) => email.email);

		account.phoneNumbers = account.phoneNumbers.filter((phoneNumber: { phoneNumber: any; }) => phoneNumber.phoneNumber);

		// Update the account on the server
		this._accountsService.updateAccount(account.id, account).subscribe(() => {
			// Toggle the edit mode off
			this.toggleEditMode(false);
		});
	}

	/**
	 * Delete the account
	 */
	deleteAccount(): void {
		// Open the confirmation dialog
		const confirmation = this._fuseConfirmationService.open({
			title: 'Delete account',
			message: 'Are you sure you want to delete this account? This action cannot be undone!',
			actions: {
				confirm: {
					label: 'Delete',
				},
			},
		});

		// Subscribe to the confirmation dialog closed action
		confirmation.afterClosed().subscribe((result) => {
			// If the confirm button pressed...
			if (result === 'confirmed') {

				if (this.account === null) {
					//TODO:: Throw an error, this shouldn't be null
					return;
				}

				if (this.accounts === null) {
					//TODO:: Throw an error, this shouldn't be null
					return;
				}

				// Get the current account's id
				const id = this.account.id;

				// Get the next/previous account's id
				const currentAccountIndex = this.accounts.findIndex(item => item.id === id);
				const nextAccountIndex = currentAccountIndex + ((currentAccountIndex === (this.accounts.length - 1)) ? -1 : 1);
				const nextAccountId = (this.accounts.length === 1 && this.accounts[0].id === id) ? null : this.accounts[nextAccountIndex].id;

				// Delete the account
				this._accountsService.deleteAccount(id)
					.subscribe((isDeleted) => {
						// Return if the account wasn't deleted...
						if (!isDeleted) {
							return;
						}

						// Navigate to the next account if available
						if (nextAccountId) {
							this._router.navigate(['../', nextAccountId], { relativeTo: this._activatedRoute });
						}
						// Otherwise, navigate to the parent
						else {
							this._router.navigate(['../'], { relativeTo: this._activatedRoute });
						}

						// Toggle the edit mode off
						this.toggleEditMode(false);
					});

				// Mark for check
				this._changeDetectorRef.markForCheck();
			}
		});

	}

	/**
	 * Upload avatar
	 *
	 * @param fileList
	 */
	uploadAvatar(fileList: FileList): void {
		// Return if canceled
		if (!fileList.length) {
			return;
		}

		if (this.account === null) {
			//TODO:: Throw an error, this shouldn't be null
			return;
		}

		const allowedTypes = ['image/jpeg', 'image/png'];
		const file = fileList[0];

		// Return if the file is not allowed
		if (!allowedTypes.includes(file.type)) {
			return;
		}

		// Upload the avatar
		this._accountsService.uploadAvatar(this.account.id, file).subscribe();
	}

	/**
	 * Remove the avatar
	 */
	removeAvatar(): void {
		if (this.account === null) {
			//TODO:: Throw an error, this shouldn't be null
			return;
		}

		// Get the form control for 'avatar'
		const avatarFormControl = this.accountForm.get('avatar');

		if (avatarFormControl === null) {
			//TODO:: Throw an error, this shouldn't be null
			return;
		}

		// Set the avatar as null
		avatarFormControl.setValue(null);

		// Set the file input value as null
		this._avatarFileInput.nativeElement.value = null;

		// Update the account
		this.account.avatar = null;
	}

	/**
	 * Open tags panel
	 */
	openTagsPanel(): void {
		// Create the overlay
		this._tagsPanelOverlayRef = this._overlay.create({
			backdropClass: '',
			hasBackdrop: true,
			scrollStrategy: this._overlay.scrollStrategies.block(),
			positionStrategy: this._overlay.position()
				.flexibleConnectedTo(this._tagsPanelOrigin.nativeElement)
				.withFlexibleDimensions(true)
				.withViewportMargin(64)
				.withLockedPosition(true)
				.withPositions([
					{
						originX: 'start',
						originY: 'bottom',
						overlayX: 'start',
						overlayY: 'top',
					},
				]),
		});

		// Subscribe to the attachments observable
		this._tagsPanelOverlayRef.attachments().subscribe(() => {
			// Add a class to the origin
			this._renderer2.addClass(this._tagsPanelOrigin.nativeElement, 'panel-opened');

			// Focus to the search input once the overlay has been attached
			this._tagsPanelOverlayRef.overlayElement.querySelector('input')!.focus();
		});

		// Create a portal from the template
		const templatePortal = new TemplatePortal(this._tagsPanel, this._viewContainerRef);

		// Attach the portal to the overlay
		this._tagsPanelOverlayRef.attach(templatePortal);

		// Subscribe to the backdrop click
		this._tagsPanelOverlayRef.backdropClick().subscribe(() => {
			// Remove the class from the origin
			this._renderer2.removeClass(this._tagsPanelOrigin.nativeElement, 'panel-opened');

			// If overlay exists and attached...
			if (this._tagsPanelOverlayRef && this._tagsPanelOverlayRef.hasAttached()) {
				// Detach it
				this._tagsPanelOverlayRef.detach();

				// Reset the tag filter
				this.filteredTags = this.tags;

				// Toggle the edit mode off
				this.tagsEditMode = false;
			}

			// If template portal exists and attached...
			if (templatePortal && templatePortal.isAttached) {
				// Detach it
				templatePortal.detach();
			}
		});
	}

	/**
	 * Toggle the tags edit mode
	 */
	toggleTagsEditMode(): void {
		this.tagsEditMode = !this.tagsEditMode;
	}

	/**
	 * Filter tags
	 *
	 * @param event
	 */
	filterTags(event: { target: { value: string; }; }): void {

		if (this.tags === null) {
			//TODO:: Throw an error, this shouldn't be null
			return;
		}

		// Get the value
		const value = event.target.value.toLowerCase();

		// Filter the tags
		this.filteredTags = this.tags.filter(tag => tag.title!.toLowerCase().includes(value));
	}

	/**
	 * Filter tags input key down event
	 *
	 * @param event
	 */
	filterTagsInputKeyDown(event: { key: string; target: { value: string; }; }): void {

		if (this.filterTags === null) {
			//TODO:: Throw an error, this shouldn't be null
			return;
		}

		if (this.account === null) {
			//TODO:: Throw an error, this shouldn't be null
			return;
		}

		// Return if the pressed key is not 'Enter'
		if (event.key !== 'Enter') {
			return;
		}

		// If there is no tag available...
		if (this.filteredTags!.length === 0) {
			// Create the tag
			this.createTag(event.target.value);

			// Clear the input
			event.target.value = '';

			// Return
			return;
		}

		// If there is a tag...
		const tag = this.filteredTags![0];
		const isTagApplied = this.account.tags.find(id => id === tag.id);

		// If the found tag is already applied to the account...
		if (isTagApplied) {
			// Remove the tag from the account
			this.removeTagFromAccount(tag);
		}
		else {
			// Otherwise add the tag to the account
			this.addTagToAccount(tag);
		}
	}

	/**
	 * Create a new tag
	 *
	 * @param title
	 */
	createTag(title: string): void {
		const tag = {
			title,
		};

		// Create tag on the server
		this._accountsService.createTag(tag)
			.subscribe((response) => {
				// Add the tag to the account
				this.addTagToAccount(response);
			});
	}

	/**
	 * Update the tag title
	 *
	 * @param tag
	 * @param event
	 */
	updateTagTitle(tag: Tag, event: { target: { value: string | undefined; }; }): void {

		// Update the title on the tag
		tag.title = event.target.value;

		// Update the tag on the server
		this._accountsService.updateTag(tag.id!, tag)
			.pipe(debounceTime(300))
			.subscribe();

		// Mark for check
		this._changeDetectorRef.markForCheck();
	}

	/**
	 * Delete the tag
	 *
	 * @param tag
	 */
	deleteTag(tag: Tag): void {

		if (tag === null) {
			//TODO:: Throw an error, this shouldn't be null
			return;
		}

		// Delete the tag from the server
		this._accountsService.deleteTag(tag.id!).subscribe();

		// Mark for check
		this._changeDetectorRef.markForCheck();
	}

	/**
	 * Add tag to the account
	 *
	 * @param tag
	 */
	addTagToAccount(tag: Tag): void {

		if (this.account === null) {
			//TODO:: Throw an error, this shouldn't be null
			return;
		}
		// Add the tag
		this.account.tags.unshift(tag.id!);

		// Update the account form
		this.accountForm.get('tags')!.patchValue(this.account.tags);

		// Mark for check
		this._changeDetectorRef.markForCheck();
	}

	/**
	 * Remove tag from the account
	 *
	 * @param tag
	 */
	removeTagFromAccount(tag: Tag): void {

		if (this.account === null) {
			//TODO:: Throw an error, this shouldn't be null
			return;
		}

		// Remove the tag
		this.account.tags.splice(this.account.tags.findIndex(item => item === tag.id), 1);

		// Update the account form
		this.accountForm.get('tags')!.patchValue(this.account.tags);

		// Mark for check
		this._changeDetectorRef.markForCheck();
	}

	/**
	 * Toggle account tag
	 *
	 * @param tag
	 */
	toggleAccountTag(tag: Tag): void {

		if (this.account === null) {
			//TODO:: Throw an error, this shouldn't be null
			return;
		}

		if (tag === null) {
			//TODO:: Throw an error, this shouldn't be null
			return;
		}

		if (this.account.tags.includes(tag.id!)) {
			this.removeTagFromAccount(tag);
		}
		else {
			this.addTagToAccount(tag);
		}
	}

	/**
	 * Should the create tag button be visible
	 *
	 * @param inputValue
	 */
	shouldShowCreateTagButton(inputValue: string): boolean {

		if (this.tags === null) {
			//TODO:: Throw an error, this shouldn't be null
			return false;
		}

		return !!!(inputValue === '' || this.tags.findIndex(tag => tag.title!.toLowerCase() === inputValue.toLowerCase()) > -1);
	}

	/**
	 * Add the email field
	 */
	addEmailField(): void {
		// Create an empty email form group
		const emailFormGroup = this._formBuilder.group({
			email: [''],
			label: [''],
		});

		// Add the email form group to the emails form array
		(this.accountForm.get('emails') as UntypedFormArray).push(emailFormGroup);

		// Mark for check
		this._changeDetectorRef.markForCheck();
	}

	/**
	 * Remove the email field
	 *
	 * @param index
	 */
	removeEmailField(index: number): void {
		// Get form array for emails
		const emailsFormArray = this.accountForm.get('emails') as UntypedFormArray;

		// Remove the email field
		emailsFormArray.removeAt(index);

		// Mark for check
		this._changeDetectorRef.markForCheck();
	}

	/**
	 * Add an empty phone number field
	 */
	addPhoneNumberField(): void {
		// Create an empty phone number form group
		const phoneNumberFormGroup = this._formBuilder.group({
			country: ['us'],
			phoneNumber: [''],
			label: [''],
		});

		// Add the phone number form group to the phoneNumbers form array
		(this.accountForm.get('phoneNumbers') as UntypedFormArray).push(phoneNumberFormGroup);

		// Mark for check
		this._changeDetectorRef.markForCheck();
	}

	/**
	 * Remove the phone number field
	 *
	 * @param index
	 */
	removePhoneNumberField(index: number): void {
		// Get form array for phone numbers
		const phoneNumbersFormArray = this.accountForm.get('phoneNumbers') as UntypedFormArray;

		// Remove the phone number field
		phoneNumbersFormArray.removeAt(index);

		// Mark for check
		this._changeDetectorRef.markForCheck();
	}

	/**
	 * Get country info by iso code
	 *
	 * @param iso
	 */
	getCountryByIso(iso: string): Country | undefined {
		if (this.countries === null) {
			//TODO:: Throw an error, this shouldn't be null
			return undefined;
		}

		return this.countries.find(country => country.iso === iso);
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


	getPhoneNumbers(): IterableIterator<string> | undefined {
		if (this.accountForm === null) {
			return undefined;
		}

		return this.accountForm.get('emails')?.value;
	}

	get phoneNumbers(): FormArray {
		return this.accountForm.get('phoneNumbers') as FormArray;
	}

	getPhoneNumberControl(phoneNumber: AbstractControl): FormControl {
		return phoneNumber.get('phoneNumber') as FormControl;
	}
}
