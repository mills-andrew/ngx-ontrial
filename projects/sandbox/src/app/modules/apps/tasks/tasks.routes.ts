import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, Routes } from '@angular/router';
import { TasksDetailsComponent } from './details/details.component';
import { TasksListComponent } from './list/list.component';
import { TasksComponent } from './tasks.component';
import { TasksService } from './tasks.service';
import { Observable, catchError, throwError } from 'rxjs';
import { Task } from './tasks.types';

/**
 * Task resolver
 *
 * @param route
 * @param state
 */
const taskResolver = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot) => {
	const tasksService = inject(TasksService);
	const router = inject(Router);

	var routeId: string | null = route.paramMap.get('id');

	if (routeId === null) {
		throw new Error("Could not find the Id in the paramMap.");
	}

	var results: Observable<Task> | null = tasksService.getTaskById(routeId);

	if (results === null) {
		throw new Error("Unable to find any tasks.");
	}

	return results.pipe(
		// Error here means the requested task is not available
		catchError((error) => {
			// Log the error
			console.error(error);

			// Get the parent url
			const parentUrl = state.url.split('/').slice(0, -1).join('/');

			// Navigate to there
			router.navigateByUrl(parentUrl);

			// Throw an error
			throw new Error(error);
		}),
	);
};

/**
 * Can deactivate tasks details
 *
 * @param component
 * @param currentRoute
 * @param currentState
 * @param nextState
 */
const canDeactivateTasksDetails = (
	component: TasksDetailsComponent,
	currentRoute: ActivatedRouteSnapshot,
	currentState: RouterStateSnapshot,
	nextState: RouterStateSnapshot) => {
	// Get the next route
	let nextRoute: ActivatedRouteSnapshot = nextState.root;
	while (nextRoute.firstChild) {
		nextRoute = nextRoute.firstChild;
	}

	// If the next state doesn't contain '/tasks'
	// it means we are navigating away from the
	// tasks app
	if (!nextState.url.includes('/tasks')) {
		// Let it navigate
		return true;
	}

	// If we are navigating to another task...
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
		component: TasksComponent,
		resolve: {
			tags: () => inject(TasksService).getTags(),
		},
		children: [
			{
				path: '',
				component: TasksListComponent,
				resolve: {
					tasks: () => inject(TasksService).getTasks(),
				},
				children: [
					{
						path: ':id',
						component: TasksDetailsComponent,
						resolve: {
							task: taskResolver,
						},
						canDeactivate: [canDeactivateTasksDetails],
					},
				],
			},
		],
	},
] as Routes;
