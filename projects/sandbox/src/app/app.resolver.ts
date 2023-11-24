import { inject } from '@angular/core';
import { forkJoin } from 'rxjs';
import { NavigationService, NotificationsService } from '@ngx-ontrial/layout';


export const initialDataResolver = () => {
	const navigationService = inject(NavigationService);
	const notificationsService = inject(NotificationsService);

	// Fork join multiple API endpoint calls to wait all of them to finish
	return forkJoin([
		navigationService.get(),
		notificationsService.getAll(),
	]);
};
