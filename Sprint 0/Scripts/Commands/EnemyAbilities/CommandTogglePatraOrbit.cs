using System.Collections.Generic;
using Sprint_0.Scripts.Enemy;

namespace Sprint_0.Scripts.Commands.EnemyAbilities
{
    public class CommandTogglePatraOrbit : ICommand
    {
        private IEnemy patra;
        private EnemyStateMachine stateMachine;

        private List<(bool extended, bool ellipse)> orbitCycle;
        private int cycleIndex = ObjectConstants.zero;

        public CommandTogglePatraOrbit(IEnemy patra, EnemyStateMachine stateMachine)
        {
            this.patra = patra;
            this.stateMachine = stateMachine;

            // Patra standard extension/formation progression
            orbitCycle = new List<(bool extended, bool ellipse)>
            {
                (false, false),
                (true, false),
                (true, true),
                (true, false),
                (false, false),
                (false, true)
            };
        }

        public void Execute()
        {
            bool lastExtensionState = ((Patra)patra).orbitState.extended;
            UpdateOrbitState();
            ((Patra)patra).ToggleOrbit(GetRadiusChange(lastExtensionState));
            stateMachine.SetState(EnemyState.AbilityCast, stateMachine.moveTime);
        }

        //----- Helpers for Patra orbit values -----//

        private void UpdateOrbitState()
        {
            cycleIndex++;
            if (cycleIndex >= orbitCycle.Count)
            {
                cycleIndex = ObjectConstants.zero;
            }
            ((Patra)patra).orbitState = orbitCycle[cycleIndex];
        }

        private double GetRadiusChange(bool lastExtensionState)
        {
            double radiusChange = ObjectConstants.zero_double;
            if (lastExtensionState && !((Patra)patra).orbitState.extended)
            {
                radiusChange = ObjectConstants.PatraRadiusExtensionSpeed;
            }
            else if (!lastExtensionState && ((Patra)patra).orbitState.extended)
            {
                radiusChange = ObjectConstants.PatraRadiusExtensionSpeed * ObjectConstants.adjustByNegativeOne;
            }
            return radiusChange;
        }
    }
}
