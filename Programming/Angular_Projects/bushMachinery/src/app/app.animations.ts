import { trigger, state, style, transition, animate } from "@angular/animations";

export const img = trigger('show', [
  state('*', style({
    height: '300px',
    opacity: 1
  })),
  state('void', style({
    height: '50px',
    opacity: 0.5
  })),
  transition('void <=> *', [
    animate('700ms')
  ])
]);

export const appear = trigger('appear', [
  state('*', style({
    opacity: 1
  })),
  state('void', style({
    height: '50px',
    opacity: 0.5
  })),
  transition('void <=> *', [
    animate('500ms')
  ])
]);