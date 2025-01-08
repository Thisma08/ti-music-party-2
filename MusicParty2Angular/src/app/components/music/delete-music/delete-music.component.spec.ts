import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteMusicComponent } from './delete-music.component';

describe('DeleteMusicComponent', () => {
  let component: DeleteMusicComponent;
  let fixture: ComponentFixture<DeleteMusicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeleteMusicComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteMusicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
