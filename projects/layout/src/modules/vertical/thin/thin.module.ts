import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { LoadingBarComponent } from '@ngx-ontrial/material';
import { ThinLayoutComponent } from './thin.component';
import { VerticalNavigationModule } from '../../../components/vertical';

@NgModule({
	declarations: [
		ThinLayoutComponent
	],
	imports: [
		RouterModule,
		MatIconModule,
		LoadingBarComponent,
		VerticalNavigationModule
	],
	exports: [
		ThinLayoutComponent,
	]
})
export class ThinLayoutModule {
}
