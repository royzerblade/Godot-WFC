using Godot;

public partial class PlayerScript : CharacterBody2D
{
	[Export]
	public float Mvt_speed = 100.0f;
	
	[Export]
	public Vector2 Starting_Direction = new(0, 1);

	public AnimationTree _animationTree;
	public AnimationNodeStateMachinePlayback StateMachine;

 	public override void _Ready()
 	{
		_animationTree = GetNode<AnimationTree>("PCAnimationTree");
		StateMachine = _animationTree.Get("parameters/playback").As<AnimationNodeStateMachinePlayback>();
		Update_animation_params(Starting_Direction);
 	}

	private void Select_new_state()
	{
		if (Velocity != Vector2.Zero) {
			StateMachine.Travel("Walk");
		}
		else 
		{
			StateMachine.Travel("Idle");
		}
	}
	private void Update_animation_params(Vector2 move_input) 
	{
		if (move_input != Vector2.Zero)
		{
			_animationTree.Set("parameters/Idle/blend_position", move_input);
			_animationTree.Set("parameters/Walk/blend_position", move_input);
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 input_direction = new(
			Input.GetActionStrength("right") - Input.GetActionStrength("left"),
			Input.GetActionStrength("down") - Input.GetActionStrength("up"));

		// update animation
		Update_animation_params(input_direction);
		Select_new_state();

		// write velocity and then use
		Velocity = input_direction * Mvt_speed;
		MoveAndSlide();
	}
}