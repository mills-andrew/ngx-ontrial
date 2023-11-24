import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, Routes } from '@angular/router';
import { AccountsComponent } from './accounts.component';
import { AccountsService } from './accounts.service';
import { AccountsDetailsComponent } from './details/details.component';
import { AccountsListComponent } from './list/list.component';
import { catchError, throwError } from 'rxjs';

/**
 * Account resolver
 *
 * @param route
 * @param state
 */
const accountResolver = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
	const accountsService = inject(AccountsService);
	const router = inject(Router);

	return accountsService.getAccountById(route.paramMap.get('id')!)
		.pipe(
			// Error here means the requested account is not available
			catchError((error) => {
				// Log the error
				console.error(error);

				// Get the parent url
				const parentUrl = state.url.split('/').slice(0, -1).join('/');

				// Navigate to there
				router.navigateByUrl(parentUrl);

				// Throw an error
				return throwError(error);
			}),
		);
};

/**
 * Can deactivate accounts details
 *
 * @param component
 * @param currentRoute
 * @param currentState
 * @param nextState
 */
const canDeactivateAccountsDetails = (
	component: AccountsDetailsComponent,
	currentRoute: ActivatedRouteSnapshot,
	currentState: RouterStateSnapshot,
	nextState: RouterStateSnapshot) => {
	// Get the next route
	let nextRoute: ActivatedRouteSnapshot = nextState.root;
	while (nextRoute.firstChild) {
		nextRoute = nextRoute.firstChild;
	}

	// If the next state doesn't contain '/accounts'
	// it means we are navigating away from the
	// accounts app
	if (!nextState.url.includes('/accounts')) {
		// Let it navigate
		return true;
	}

	// If we are navigating to another account...
	if (nextRoute.paramMap.get('id')) {
		// Just navigate
		return true;
	}

	// Otherwise, close the drawer first, and then navigate
	return component.closeDrawer().then(() => true);
};

export default [
	{
		path: '',
		component: AccountsComponent,
		resolve: {
			tags: () => inject(AccountsService).getTags(),
		},
		children: [
			{
				path: '',
				component: AccountsListComponent,
				resolve: {
					accounts: () => inject(AccountsService).getAccounts(),
					countries: () => inject(AccountsService).getCountries(),
				},
				children: [
					{
						path: ':id',
						component: AccountsDetailsComponent,
						resolve: {
							account: accountResolver,
							countries: () => inject(AccountsService).getCountries(),
						},
						canDeactivate: [canDeactivateAccountsDetails],
					},
				],
			},
		],
	},
] as Routes;
