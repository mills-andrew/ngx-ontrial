import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { TemplatePortal } from '@angular/cdk/portal';
import { TextFieldModule } from '@angular/cdk/text-field';
import { DatePipe, NgClass, NgFor, NgIf } from '@angular/common';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, ElementRef, OnDestroy, OnInit, Renderer2, TemplateRef, ViewChild, ViewContainerRef, ViewEncapsulation } from '@angular/core';
import { FormsModule, ReactiveFormsModule, UntypedFormArray, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
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
import { ICountryModel, ITagModel, IUserModel } from '../users.types';
import { UsersListComponent } from '../list/list.component';
import { UsersService } from '../users.service';
import { ConfirmationService, FindByKeyPipe } from '@ngx-ontrial/core';

@Component({
	selector: 'users-details',
	templateUrl: './details.component.html',
	encapsulation: ViewEncapsulation.None,
	changeDetection: ChangeDetectionStrategy.OnPush,
	standalone: true,
	imports: [NgIf, MatButtonModule, MatTooltipModule, RouterLink, MatIconModule, NgFor, FormsModule, ReactiveFormsModule, MatRippleModule, MatFormFieldModule, MatInputModule, MatCheckboxModule, NgClass, MatSelectModule, MatOptionModule, MatDatepickerModule, TextFieldModule, FindByKeyPipe, DatePipe],
})
export class UsersDetailsComponent implements OnInit, OnDestroy {
	@ViewChild('avatarFileInput') private _avatarFileInput!: ElementRef;
	@ViewChild('tagsPanel') private _tagsPanel!: TemplateRef<any>;
	@ViewChild('tagsPanelOrigin') private _tagsPanelOrigin!: ElementRef;

	editMode: boolean = false;
	tags: ITagModel[] | null = null;
	tagsEditMode: boolean = false;
	filteredTags: ITagModel[] | null = null;
	user: IUserModel | null = null;
	userForm: UntypedFormGroup;
	users: IUserModel[] | null = null;
	countries: ICountryModel[] | null = null;
	private _tagsPanelOverlayRef!: OverlayRef;
	private _unsubscribeAll: Subject<any> = new Subject<any>();

	/**
	 * Constructor
	 */
	constructor(
		private _activatedRoute: ActivatedRoute,
		private _changeDetectorRef: ChangeDetectorRef,
		private _usersListComponent: UsersListComponent,
		private _usersService: UsersService,
		private _formBuilder: UntypedFormBuilder,
		private _confirmationService: ConfirmationService,
		private _renderer2: Renderer2,
		private _router: Router,
		private _overlay: Overlay,
		private _viewContainerRef: ViewContainerRef,
	) {
		this.userForm = this._formBuilder.group({

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
		this._usersListComponent.matDrawer.open();

		// Create the user form
		this.userForm = this._formBuilder.group({
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

		// Get the users
		this._usersService.users$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((users: IUserModel[] | null) => {
				this.users = users;

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});

		// Get the user
		this._usersService.user$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((user: IUserModel | null) => {
				// Open the drawer in case it is closed
				this._usersListComponent.matDrawer.open();

				// Get the user
				this.user = user;

				// Clear the emails and phoneNumbers form arrays
				(this.userForm.get('emails') as UntypedFormArray).clear();
				(this.userForm.get('phoneNumbers') as UntypedFormArray).clear();

				// Patch values to the form
				this.userForm.patchValue(user!);

				// Setup the emails form array
				const emailFormGroups = [];

				if (user !== null && user.emails!.length > 0) {
					// Iterate through them
					user.emails!.forEach((email) => {
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
					(this.userForm.get('emails') as UntypedFormArray).push(emailFormGroup);
				});

				// Setup the phone numbers form array
				const phoneNumbersFormGroups = [];

				if (user !== null && user.phoneNumbers!.length > 0) {
					// Iterate through them
					user.phoneNumbers!.forEach((phoneNumber) => {
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
					(this.userForm.get('phoneNumbers') as UntypedFormArray).push(phoneNumbersFormGroup);
				});

				// Toggle the edit mode off
				this.toggleEditMode(false);

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});

		// Get the country telephone codes
		this._usersService.countries$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((codes: ICountryModel[] | null) => {
				this.countries = codes;

				// Mark for check
				this._changeDetectorRef.markForCheck();
			});

		// Get the tags
		this._usersService.tags$
			.pipe(takeUntil(this._unsubscribeAll))
			.subscribe((tags: ITagModel[] | null) => {
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
		return this._usersListComponent.matDrawer.close();
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
	 * Update the user
	 */
	updateUser(): void {
		// Get the user object
		const user = this.userForm.getRawValue();

		// Go through the user object and clear empty values
		user.emails = user.emails.filter((email: { email: any; }) => email.email);

		user.phoneNumbers = user.phoneNumbers.filter((phoneNumber: { phoneNumber: any; }) => phoneNumber.phoneNumber);

		// Update the user on the server
		this._usersService.updateUser(user.id, user).subscribe(() => {
			// Toggle the edit mode off
			this.toggleEditMode(false);
		});
	}

	/**
	 * Delete the user
	 */
	deleteUser(): void {
		// Open the confirmation dialog
		const confirmation = this._confirmationService.open({
			title: 'Delete user',
			message: 'Are you sure you want to delete this user? This action cannot be undone!',
			actions: {
				confirm: {
					label: 'Delete',
				},
			},
		});

		// Subscribe to the confirmation dialog closed action
		confirmation.afterClosed().subscribe((result: string) => {
			// If the confirm button pressed...
			if (result === 'confirmed') {
				// Get the current user's id
				const id = this.user!.id;

				// Get the next/previous user's id
				const currentUserIndex = this.users!.findIndex(item => item.id === id);
				const nextUserIndex = currentUserIndex + ((currentUserIndex === (this.users!.length - 1)) ? -1 : 1);
				const nextUserId = (this.users!.length === 1 && this.users![0].id === id) ? null : this.users![nextUserIndex].id;

				// Delete the user
				this._usersService.deleteUser(id)
					.subscribe((isDeleted) => {
						// Return if the user wasn't deleted...
						if (!isDeleted) {
							return;
						}

						// Navigate to the next user if available
						if (nextUserId) {
							this._router.navigate(['../', nextUserId], { relativeTo: this._activatedRoute });
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

		const allowedTypes = ['image/jpeg', 'image/png'];
		const file = fileList[0];

		// Return if the file is not allowed
		if (!allowedTypes.includes(file.type)) {
			return;
		}

		// Upload the avatar
		this._usersService.uploadAvatar(this.user!.id, file).subscribe();
	}

	/**
	 * Remove the avatar
	 */
	removeAvatar(): void {
		// Get the form control for 'avatar'
		const avatarFormControl = this.userForm.get('avatar');

		// Set the avatar as null
		avatarFormControl!.setValue(null);

		// Set the file input value as null
		this._avatarFileInput.nativeElement.value = null;

		// Update the user
		this.user!.avatar = null;
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
	filterTags(event: any): void {
		// Get the value
		const value = event.target.value.toLowerCase();

		// Filter the tags
		this.filteredTags = this.tags!.filter(tag => tag.title!.toLowerCase().includes(value));
	}

	/**
	 * Filter tags input key down event
	 *
	 * @param event
	 */
	filterTagsInputKeyDown(event: any): void {
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
		const isITagModelApplied = this.user!.tags.find(id => id === tag.id);

		// If the found tag is already applied to the user...
		if (isITagModelApplied) {
			// Remove the tag from the user
			this.removeTagFromUser(tag);
		}
		else {
			// Otherwise add the tag to the user
			this.addTagToUser(tag);
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
		this._usersService.createTag(tag)
			.subscribe((response: ITagModel) => {
				// Add the tag to the user
				this.addTagToUser(response);
			});
	}

	/**
	 * Update the tag title
	 *
	 * @param tag
	 * @param event
	 */
	updateTagTitle(tag: ITagModel, event: any): void {
		// Update the title on the tag
		tag.title = event.target.value;

		// Update the tag on the server
		this._usersService.updateTag(tag.id!, tag)
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
	deleteTag(tag: ITagModel): void {
		// Delete the tag from the server
		this._usersService.deleteTag(tag.id!).subscribe();

		// Mark for check
		this._changeDetectorRef.markForCheck();
	}

	/**
	 * Add tag to the user
	 *
	 * @param tag
	 */
	addTagToUser(tag: ITagModel): void {
		// Add the tag
		this.user!.tags.unshift(tag.id!);

		// Update the user form
		this.userForm.get('tags')!.patchValue(this.user!.tags);

		// Mark for check
		this._changeDetectorRef.markForCheck();
	}

	/**
	 * Remove tag from the user
	 *
	 * @param tag
	 */
	removeTagFromUser(tag: ITagModel): void {
		// Remove the tag
		this.user!.tags.splice(this.user!.tags.findIndex(item => item === tag.id), 1);

		// Update the user form
		this.userForm.get('tags')!.patchValue(this.user!.tags);

		// Mark for check
		this._changeDetectorRef.markForCheck();
	}

	/**
	 * Toggle user tag
	 *
	 * @param tag
	 */
	toggleUserTag(tag: ITagModel): void {
		if (this.user!.tags.includes(tag.id!)) {
			this.removeTagFromUser(tag);
		}
		else {
			this.addTagToUser(tag);
		}
	}

	/**
	 * Should the create tag button be visible
	 *
	 * @param inputValue
	 */
	shouldShowCreateTagButton(inputValue: string): boolean {
		return !!!(inputValue === '' || this.tags!.findIndex(tag => tag.title!.toLowerCase() === inputValue.toLowerCase()) > -1);
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
		(this.userForm.get('emails') as UntypedFormArray).push(emailFormGroup);

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
		const emailsFormArray = this.userForm.get('emails') as UntypedFormArray;

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
		(this.userForm.get('phoneNumbers') as UntypedFormArray).push(phoneNumberFormGroup);

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
		const phoneNumbersFormArray = this.userForm.get('phoneNumbers') as UntypedFormArray;

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
	getCountryByIso(iso: string): ICountryModel | undefined {
		return this.countries!.find(country => country.iso === iso);
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
