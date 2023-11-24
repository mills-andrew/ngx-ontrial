import { Route } from '@angular/router';
import { AuthGuard, NoAuthGuard } from '@ngx-ontrial/auth';
import { initialDataResolver } from './app.resolver';
import { LayoutComponent } from '@ngx-ontrial/layout';

export const appRoutes: Route[] = [
	{ path: '', pathMatch: 'full', redirectTo: 'home' },

	// No Authenticated routes
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
			{ path: 'sign-up', loadChildren: () => import('@ngx-ontrial/auth').then(m => m.SignUpRoutingModule) },
			{ path: 'maintenance', loadChildren: () => import('@ngx-ontrial/common').then(m => m.MaintenanceRoutingModule) }
		]
	},

	// Routes for authenticated users
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

	// App routes for authenticated users
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
			{ path: 'settings', loadChildren: () => import('./modules/settings/settings.routes') },
			{ path: 'accounts', loadChildren: () => import('./modules/apps/accounts/accounts.routes') }
		]
	},

	// Dashboards
	{
		path: 'dashboards',
		canActivate: [AuthGuard],
		canActivateChild: [AuthGuard],
		component: LayoutComponent,
		resolve: {
			initialData: initialDataResolver
		},
		children: [
			{ path: 'analytics', loadChildren: () => import('./modules/dashboards/analytics/analytics.routes') },
			{ path: 'finance', loadChildren: () => import('./modules/dashboards/finance/finance.routes') },
			{ path: 'project', loadChildren: () => import('./modules/dashboards/project/project.routes') }
		]
	},

	// Apps
	{
		path: 'apps',
		canActivate: [AuthGuard],
		canActivateChild: [AuthGuard],
		component: LayoutComponent,
		resolve: {
			initialData: initialDataResolver
		},
		children: [
			{ path: 'ecommerce', loadChildren: () => import('./modules/apps/ecommerce/ecommerce.routes') },
			{ path: 'help-center', loadChildren: () => import('./modules/apps/help-center/help-center.routes') },
			{ path: 'tasks', loadChildren: () => import('./modules/apps/tasks/tasks.routes') },
			{ path: 'notes', loadChildren: () => import('./modules/apps/notes/notes.routes') },
			{ path: 'scrumboard', loadChildren: () => import('./modules/apps/scrumboard/scrumboard.routes') },
			{ path: 'file-manager', loadChildren: () => import('./modules/apps/file-manager/file-manager.routes') },
			{ path: 'chat', loadChildren: () => import('./modules/apps/chat/chat.routes') }
		]
	},

	// Other routes
	{
		path: '',
		canActivate: [AuthGuard],
		canActivateChild: [AuthGuard],
		component: LayoutComponent,
		resolve: {
			initialData: initialDataResolver
		},
		data: {
			layout: 'empty'
		},
		children: [
			// 404 & Catch all
			{ path: '404-not-found', pathMatch: 'full', loadChildren: () => import('@ngx-ontrial/common').then(m => m.Error404RoutingModule) },
			{ path: '**', redirectTo: '404-not-found' }
		]
	}
];

export const maintenaceRoutes: Route[] = [
	{ path: '**', redirectTo: '' },
	{
		path: '',
		children: [
			{ path: '**', pathMatch: 'full', loadChildren: () => import('@ngx-ontrial/common').then(m => m.MaintenanceRoutingModule) }
		]
	}
];