import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ClassyLayoutComponent } from './classy.component';
import { LoadingBarComponent } from '@ngx-ontrial/material';
import { VerticalNavigationModule } from '../../../components/vertical';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
	declarations: [
		ClassyLayoutComponent
	],
	imports: [
		RouterModule,
		MatIconModule,
		LoadingBarComponent,
		VerticalNavigationModule
	],
	exports: [
		ClassyLayoutComponent,
	]
})
export class ClassyLayoutModule {
}
