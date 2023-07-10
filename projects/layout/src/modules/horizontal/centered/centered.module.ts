import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { LoadingBarComponent } from '@ngx-ontrial/material';
import { CenteredLayoutComponent } from './centered.component';
import { VerticalNavigationModule } from '../../../components/vertical';
import { HorizontalNavigationModule } from '../../../components/horizontal';

@NgModule({
	declarations: [
		CenteredLayoutComponent
	],
	imports: [
		RouterModule,
		MatIconModule,
		LoadingBarComponent,
		VerticalNavigationModule,
		HorizontalNavigationModule
	],
	exports: [
		CenteredLayoutComponent,
	]
})
export class CenteredLayoutModule {
}
