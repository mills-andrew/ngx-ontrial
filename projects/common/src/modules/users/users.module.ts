import { NgModule, inject } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterModule, RouterStateSnapshot, Routes } from '@angular/router';
import { UsersComponent } from './users.component';
import { UsersService } from './users.service';
import { UsersDetailsComponent, UsersListComponent } from './public-api';
import { catchError, of, throwError } from 'rxjs';

/**
 * User resolver
 *
 * @param route
 * @param state
 */
const userResolver = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
	const usersService = inject(UsersService);
	const router = inject(Router);

	const id = route.paramMap.get('id');

	if (id === null) {
		// Handle the case when id is null
		// You can adjust this behavior to fit your application's needs
		console.error('User ID not found');
		router.navigateByUrl('/error');
		return of(null); // Return an Observable of null
	} else {
		return usersService.getUserById(id)
			.pipe(
				// Error here means the requested user is not available
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
	}
};


/**
 * Can deactivate users details
 *
 * @param component
 * @param currentRoute
 * @param currentState
 * @param nextState
 */
const canDeactivateUsersDetails = (
	component: UsersDetailsComponent,
	currentRoute: ActivatedRouteSnapshot,
	currentState: RouterStateSnapshot,
	nextState: RouterStateSnapshot) => {
	// Get the next route
	let nextRoute: ActivatedRouteSnapshot = nextState.root;
	while (nextRoute.firstChild) {
		nextRoute = nextRoute.firstChild;
	}

	// If the next state doesn't contain '/users'
	// it means we are navigating away from the
	// users app
	if (!nextState.url.includes('/users')) {
		// Let it navigate
		return true;
	}

	// If we are navigating to another user...
	if (nextRoute.paramMap.get('id')) {
		// Just navigate
		return true;
	}

	// Otherwise, close the drawer first, and then navigate
	return component.closeDrawer().then(() => true);
};

const routes: Routes = [
	{
		path: '',
		component: UsersComponent,
		resolve: {
			tags: () => inject(UsersService).getTags(),
		},
		children: [
			{
				path: '',
				component: UsersListComponent,
				resolve: {
					users: () => inject(UsersService).getUsers(),
					countries: () => inject(UsersService).getCountries(),
				},
				children: [
					{
						path: ':id',
						component: UsersDetailsComponent,
						resolve: {
							user: userResolver,
							countries: () => inject(UsersService).getCountries(),
						},
						canDeactivate: [canDeactivateUsersDetails],
					},
				],
			},
		],
	}
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class UsersRoutingModule { }
