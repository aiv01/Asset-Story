using UnityEngine;

public class Spikes : Trap {
    #region Start methods
    protected override void VariablesAssignment() {
        base.VariablesAssignment();
        myCollider.isTrigger = true;
        mySpriteRenderer.sprite = databaseTrap.SpriteRandom;
    }
    #endregion



    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            playerDatabaseHealth.TakeDamage(databaseTrap.Damage);
        }
    }
}
