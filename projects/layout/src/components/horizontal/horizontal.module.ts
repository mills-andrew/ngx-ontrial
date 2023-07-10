import { NgModule } from '@angular/core';
import { HorizontalNavigationComponent } from './horizontal.component';
import { HorizontalNavigationSpacerItemModule } from './components/spacer/spacer.module';
import { HorizontalNavigationBasicItemModule } from './components/basic/basic.module';

@NgModule({
	declarations: [
		HorizontalNavigationComponent
	],
	imports: [
		HorizontalNavigationBasicItemModule,
		HorizontalNavigationSpacerItemModule,
		HorizontalNavigationSpacerItemModule
	],
	exports: [
		HorizontalNavigationComponent,
	]
})
export class HorizontalNavigationModule {
}
