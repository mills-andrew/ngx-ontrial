import { Route } from '@angular/router';
import { AuthGuard, NoAuthGuard } from '@ngx-ontrial/auth';
import { initialDataResolver } from './app.resolver';
//import { LayoutComponent } from './layouts/modules/layout.component';
import { LayoutComponent } from '@ngx-ontrial/layout';

// @formatter:off
/* eslint-disable max-len */
/* eslint-disable @typescript-eslint/explicit-function-return-type */
export const appRoutes: Route[] = [

	{ path: '', pathMatch: 'full', redirectTo: 'home' },

	// Auth routes for guests
	{
		path: '',
		canActivate: [NoAuthGuard],
		canActivateChild: [NoAuthGuard],
		component: LayoutComponent,
		data: {
			layout: 'empty'
		},
		children: [
			{ path: 'confirmation-required', loadChildren: () => import('@ngx-ontrial/auth').then(m => m.ConfirmationRequiredRoutingModule) },
			{ path: 'forgot-password', loadChildren: () => import('@ngx-ontrial/auth').then(m => m.ForgotPasswordRoutingModule) },
			{ path: 'reset-password', loadChildren: () => import('@ngx-ontrial/auth').then(m => m.ResetPasswordRoutingModule) },
			{ path: 'sign-in', loadChildren: () => import('@ngx-ontrial/auth').then(m => m.SignInRoutingModule) },
			{ path: 'sign-up', loadChildren: () => import('@ngx-ontrial/auth').then(m => m.SignUpRoutingModule) }
		]
	},

	// Auth routes for authenticated users
	{
		path: '',
		canActivate: [AuthGuard],
		canActivateChild: [AuthGuard],
		component: LayoutComponent,
		data: {
			layout: 'empty'
		},
		children: [
			{ path: 'sign-out', loadChildren: () => import('@ngx-ontrial/auth').then(m => m.SignOutRoutingModule) },
			{ path: 'unlock-session', loadChildren: () => import('@ngx-ontrial/auth').then(m => m.UnlockSessionRoutingModule) }
		]
	},

	// Landing routes
	{
		path: '',
		canActivate: [AuthGuard],
		canActivateChild: [AuthGuard],
		component: LayoutComponent,
		resolve: {
			initialData: initialDataResolver
		},
		children: [
			{ path: 'home', loadChildren: () => import('./modules/home/home.routes') },
			{ path: 'users', loadChildren: () => import('@ngx-ontrial/common').then(m => m.UsersRoutingModule) },
		]
	},

	// Admin routes
	{
		path: '',
		canActivate: [AuthGuard],
		canActivateChild: [AuthGuard],
		component: LayoutComponent,
		resolve: {
			initialData: initialDataResolver
		},
		children: [
			// 404 & Catch all
			{ path: '404-not-found', pathMatch: 'full', loadChildren: () => import('@ngx-ontrial/common').then(m => m.Error404RoutingModule) },
			{ path: '**', redirectTo: '404-not-found' }
		]
	}
];
