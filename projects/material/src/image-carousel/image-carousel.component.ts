import { animate, style, transition, trigger } from '@angular/animations';
import { CommonModule } from '@angular/common';
import { Component, HostListener, Input, OnDestroy, OnInit } from '@angular/core';

@Component({
	selector: 'ontrial-image-carousel',
	templateUrl: './image-carousel.component.html',
	styleUrls: ['./image-carousel.component.scss'],
	standalone: true,
	animations: [
		trigger('fadeInOut', [
			transition(':enter', [
				style({ opacity: 0 }),
				animate('0.5s ease-in-out', style({ opacity: 1 }))
			]),
			transition(':leave', [
				animate('0.5s ease-in-out', style({ opacity: 0 }))
			])
		])
	],
	imports: [CommonModule]
})
export class ImageCarouselComponent implements OnInit, OnDestroy {
	@Input() images = [
		{ src: 'assets/images/carousel/Lowells_Truck_02-Small.jpg', caption: '"...thank you for the excellent service provided by your crew of four men. Your employees were extremely efficient, courteous, and meticulous with my belongings." -D. Cook' },
		{ src: 'assets/images/carousel/staff1.jpg', caption: '"...your guys showed up on time, were courteous, and worked hard to move our belongings. I would tell anyone who asked that you run your company with integrity." -A. Newcomb' },
	];

	@Input() autoplaySpeed = 50;
	@Input() enableFullscreen = false;
	@Input() enablePauseAndResume = false;
	@Input() enableAutoRotate = true;
	@Input() enableKeyboardActions = false;
	@Input() enableImageLoop = true;
	@Input() enableCaptions = false;

	currentImageIndex = 0;
	autoRotateTimeout: any;
	progress = 0;

	ngOnInit() {
		try {
			for (let image of this.images) {
				const img = new Image();
				img.src = image.src;
			}

			this.currentImageIndex = Math.floor(Math.random() * this.images.length);
			this.autoRotate();
		} catch (error) {
			console.error('Error initializing component', error);
		}
	}

	autoRotate() {
		if (!this.enableAutoRotate) {
			return;
		}

		if (this.autoRotateTimeout) {
			clearInterval(this.autoRotateTimeout);
		}

		this.autoRotateTimeout = setInterval(() => {
			this.progress += 100 / this.autoplaySpeed;
			if (this.progress >= 100) {
				this.onNext();
			}
		}, 100);
	}

	pauseRotation() {
		if (!this.enablePauseAndResume) {
			return;
		}

		clearInterval(this.autoRotateTimeout);
	}

	resumeRotation() {
		if (!this.enablePauseAndResume) {
			return;
		}
		this.autoRotate();
	}

	resetAutoRotate() {
		clearInterval(this.autoRotateTimeout);
		this.progress = 0;
		this.autoRotate();
	}

	onNext() {
		this.currentImageIndex = (this.currentImageIndex + 1) % this.images.length;
		this.resetAutoRotate();
	}

	onPrevious() {
		this.currentImageIndex = (this.currentImageIndex - 1 + this.images.length) % this.images.length;
		this.resetAutoRotate();
	}

	goToImage(index: number) {
		this.currentImageIndex = index;
		this.resetAutoRotate();
	}

	requestFullscreen(element: HTMLElement) {
		try {
			if (element.requestFullscreen) {
				element.requestFullscreen();
			} else if ((element as any).mozRequestFullScreen) { /* Firefox */
				(element as any).mozRequestFullScreen();
			} else if ((element as any).webkitRequestFullscreen) { /* Chrome, Safari & Opera */
				(element as any).webkitRequestFullscreen();
			} else if ((element as any).msRequestFullscreen) { /* IE/Edge */
				(element as any).msRequestFullscreen();
			}
		} catch (error) {
			console.error('Error requesting fullscreen', error);
		}
	}

	@HostListener('window:keydown', ['$event'])
	handleKeyDown(event: KeyboardEvent) {
		if (!this.enableKeyboardActions) {
			return;
		}

		if (event.key === 'ArrowRight') {
			this.onNext();
		} else if (event.key === 'ArrowLeft') {
			this.onPrevious();
		}
	}

	ngOnDestroy() {
		try {
			clearInterval(this.autoRotateTimeout);
		} catch (error) {
			console.error('Error clearing interval on component destruction', error);
		}
	}
}