import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateVoteComponent } from './create-vote.component';

describe('AddVoteComponent', () => {
  let component: CreateVoteComponent;
  let fixture: ComponentFixture<CreateVoteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateVoteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateVoteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
