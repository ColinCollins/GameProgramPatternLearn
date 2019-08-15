using System;
using System.Collections;
using System.Collections.Generic;

public class Terrain {
        private int moveCost_;
        private bool isWater_;
        private Texture texture_;

        public Terrian (int movementCost, bool isWater, Texture texture) {
            moveCost_ = movementCost;
            isWater_ = isWater;
            texture_ = texture;
        }

        public int getMoveCost () {
            return moveCost_;
        }

        bool isWater () {
            return isWater_;
        }

        Texture getTexture () {
            return texture_;
        }

}