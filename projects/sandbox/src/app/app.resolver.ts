import { inject } from '@angular/core';
import { forkJoin } from 'rxjs';
//import { NavigationService } from './layouts/common/navigation.service';
import { NavigationService } from '@ngx-ontrial/layout';


export const initialDataResolver = () => {
	const navigationService = inject(NavigationService);

	// Fork join multiple API endpoint calls to wait all of them to finish
	return forkJoin([
		navigationService.get()
	]);
};
