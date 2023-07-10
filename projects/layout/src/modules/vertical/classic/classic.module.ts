import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ClassicLayoutComponent } from './classic.component';
import { LoadingBarComponent } from '@ngx-ontrial/material';
import { VerticalNavigationModule } from '../../../components/vertical';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
	declarations: [
		ClassicLayoutComponent
	],
	imports: [
		RouterModule,
		MatIconModule,
		LoadingBarComponent,
		VerticalNavigationModule
	],
	exports: [
		ClassicLayoutComponent,
	]
})
export class ClassicLayoutModule {
}
