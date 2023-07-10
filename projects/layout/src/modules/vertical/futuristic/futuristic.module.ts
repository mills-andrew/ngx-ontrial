import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { FuturisticLayoutComponent } from './futuristic.component';
import { LoadingBarComponent } from '@ngx-ontrial/material';
import { VerticalNavigationModule } from '../../../components/vertical';

@NgModule({
	declarations: [
		FuturisticLayoutComponent
	],
	imports: [
		RouterModule,
		MatIconModule,
		LoadingBarComponent,
		VerticalNavigationModule
	],
	exports: [
		FuturisticLayoutComponent,
	]
})
export class FuturisticLayoutModule {
}
