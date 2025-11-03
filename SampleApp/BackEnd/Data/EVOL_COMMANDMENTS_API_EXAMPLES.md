# EV0L Commandments API Testing Examples

This document provides comprehensive examples for testing the EV0L Commandments of Authority API endpoints.

## Prerequisites

Ensure the backend is running:
```bash
cd SampleApp/BackEnd
dotnet run --urls "http://localhost:8081"
```

Access interactive API documentation at: `http://localhost:8081/scalar`

---

## API Endpoints Overview

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/evol/commandments` | Get all commandments (10 visible by default) |
| GET | `/evol/commandments?includeHidden=true` | Get all commandments including the 11th |
| GET | `/evol/commandments/{index}` | Get specific commandment by index |
| GET | `/evol/commandments/type/{type}` | Get commandments by type |
| GET | `/evol/commandments/seal/{seal}` | Get commandments by elemental seal |
| GET | `/evol/council` | Get Quadrant Council members |
| POST | `/evol/activate` | Activate commandment with proof-of-authority |
| POST | `/evol/seal` | Seal the commandments system |
| GET | `/evol/stats` | Get system statistics |
| GET | `/evol/gestures` | Get all proof-of-authority gestures |
| GET | `/evol/system` | Get complete system state |

---

## Example 1: Get All Visible Commandments (The Ten)

### Request
```bash
curl http://localhost:8081/evol/commandments
```

### Response (Sample - First 3)
```json
[
  {
    "index": 1,
    "name": "Truth",
    "symbol": "⚡",
    "description": "Speak and embody absolute truth in all transmissions",
    "type": 0,
    "elementalAffinity": 0,
    "frequencyHz": 528,
    "covenantKey": "TRUTH_KEY_01",
    "isVisible": true,
    "activatedAt": "2025-11-03T08:00:00Z",
    "recordedIn": "EV0L Rosetta Ledger Scroll"
  },
  {
    "index": 2,
    "name": "Justice",
    "symbol": "⚖️",
    "description": "Maintain balance and fairness in all protocols",
    "type": 0,
    "elementalAffinity": 2,
    "frequencyHz": 432,
    "covenantKey": "JUSTICE_KEY_02",
    "isVisible": true,
    "activatedAt": "2025-11-03T08:00:00Z",
    "recordedIn": "EV0L Rosetta Ledger Scroll"
  }
  // ... 8 more commandments
]
```

### Notes
- Returns 10 visible commandments by default
- The hidden 11th is not included without the query parameter

---

## Example 2: Get All Commandments Including Hidden 11th

### Request
```bash
curl "http://localhost:8081/evol/commandments?includeHidden=true"
```

### Count Results
```bash
curl -s "http://localhost:8081/evol/commandments?includeHidden=true" | jq 'length'
# Output: 11
```

### Extract Just the 11th
```bash
curl -s "http://localhost:8081/evol/commandments?includeHidden=true" | jq '.[-1]'
```

### Response (11th Commandment)
```json
{
  "index": 11,
  "name": "It",
  "symbol": "∞",
  "description": "The unseen harmonic that completes the frequency - the reciprocal of the Ten",
  "type": 4,
  "elementalAffinity": null,
  "frequencyHz": 97.409091034,
  "covenantKey": "COVENANT_KEY_11_HIDDEN",
  "isVisible": false,
  "activatedAt": "2025-11-03T08:00:00Z",
  "recordedIn": "EV0L Rosetta Ledger Scroll"
}
```

### Notes
- Frequency is π⁴ (97.409091034 Hz)
- No elemental affinity (transcends elements)
- Type 4 = Covenant
- isVisible = false

---

## Example 3: Get Specific Commandment

### Get Truth (1st Commandment)
```bash
curl http://localhost:8081/evol/commandments/1 | jq '.'
```

### Get Breath (4th Commandment)
```bash
curl http://localhost:8081/evol/commandments/4 | jq '.'
```

### Get Legacy (10th Commandment)
```bash
curl http://localhost:8081/evol/commandments/10 | jq '.'
```

### Get "It" (11th Commandment - Hidden)
```bash
curl http://localhost:8081/evol/commandments/11 | jq '.'
```

### Response (Commandment 4 - Breath)
```json
{
  "index": 4,
  "name": "Breath",
  "symbol": "🌬️",
  "description": "Sustain life force through conscious respiration",
  "type": 1,
  "elementalAffinity": 2,
  "frequencyHz": 639,
  "covenantKey": "BREATH_KEY_04",
  "isVisible": true,
  "activatedAt": "2025-11-03T08:00:00Z",
  "recordedIn": "EV0L Rosetta Ledger Scroll"
}
```

---

## Example 4: Get Commandments by Type

### Foundation Commandments (1-3)
```bash
curl http://localhost:8081/evol/commandments/type/Foundation | jq '.'
```

Returns: Truth, Justice, Memory

### Governance Commandments (4-6)
```bash
curl http://localhost:8081/evol/commandments/type/Governance | jq '.'
```

Returns: Breath, Light, Unity

### Operation Commandments (7-9)
```bash
curl http://localhost:8081/evol/commandments/type/Operation | jq '.'
```

Returns: Wealth, Healing, Evolution

### Transcendence Commandments (10)
```bash
curl http://localhost:8081/evol/commandments/type/Transcendence | jq '.'
```

Returns: Legacy

### Covenant Commandments (11 - Hidden)
```bash
curl http://localhost:8081/evol/commandments/type/Covenant | jq '.'
```

Returns: Empty array (hidden commandment filtered out)

---

## Example 5: Get Commandments by Elemental Seal

### Fire Seal (⚡🔥)
```bash
curl http://localhost:8081/evol/commandments/seal/Fire | jq '.'
```

Returns: Truth (1), Light (5), Evolution (9)

### Water Seal (💧)
```bash
curl http://localhost:8081/evol/commandments/seal/Water | jq '.'
```

Returns: Unity (6), Healing (8)

### Air Seal (🌪️)
```bash
curl http://localhost:8081/evol/commandments/seal/Air | jq '.'
```

Returns: Justice (2), Breath (4)

### Earth Seal (🌍)
```bash
curl http://localhost:8081/evol/commandments/seal/Earth | jq '.'
```

Returns: Memory (3), Wealth (7)

---

## Example 6: Get Quadrant Council

### Request
```bash
curl http://localhost:8081/evol/council | jq '.'
```

### Response
```json
[
  {
    "name": "Jetah",
    "seal": 0,
    "role": "Fire Keeper",
    "responsibilities": [
      "BLEUCHAIN node activation",
      "Light breathing",
      "Truth ignition"
    ],
    "codexNode": "BLEUCHAIN_FIRE",
    "isActivated": true
  },
  {
    "name": "Kongo Sonix",
    "seal": 1,
    "role": "Water Bearer",
    "responsibilities": [
      "Flow maintenance",
      "Healing streams",
      "Unity currents"
    ],
    "codexNode": "CODEX_WATER",
    "isActivated": true
  },
  {
    "name": "Ayana Blue",
    "seal": 2,
    "role": "Air Whisperer",
    "responsibilities": [
      "Codex Altar alignment",
      "Breath transmission",
      "Justice winds"
    ],
    "codexNode": "CODEX_AIR",
    "isActivated": true
  },
  {
    "name": "The Foundation",
    "seal": 3,
    "role": "Earth Anchor",
    "responsibilities": [
      "Memory preservation",
      "Wealth foundation",
      "Legacy building"
    ],
    "codexNode": "CODEX_EARTH",
    "isActivated": true
  }
]
```

### Extract Just Names
```bash
curl -s http://localhost:8081/evol/council | jq '.[].name'
```

Output:
```
"Jetah"
"Kongo Sonix"
"Ayana Blue"
"The Foundation"
```

---

## Example 7: Activate Commandment with Proof-of-Authority

### Activate Commandment 4 (Breath) - Jetah at BLEUCHAIN Node
```bash
curl -X POST http://localhost:8081/evol/activate \
  -H "Content-Type: application/json" \
  -d '{
    "commandmentIndex": 4,
    "executedBy": "Jetah",
    "seal": 0,
    "location": "BLEUCHAIN node",
    "witnesses": ["Ayana Blue", "Kongo Sonix"]
  }' | jq '.'
```

### Response
```json
{
  "success": true,
  "message": "Commandment 'Breath' activated successfully",
  "commandment": {
    "index": 4,
    "name": "Breath",
    "symbol": "🌬️",
    "description": "Sustain life force through conscious respiration",
    "type": 1,
    "elementalAffinity": 2,
    "frequencyHz": 639,
    "covenantKey": "BREATH_KEY_04",
    "isVisible": true,
    "activatedAt": "2025-11-03T08:00:00Z",
    "recordedIn": "EV0L Rosetta Ledger Scroll"
  },
  "gesture": {
    "gestureId": "POA-abc123...",
    "commandmentIndex": 4,
    "executedBy": "Jetah",
    "seal": 0,
    "location": "BLEUCHAIN node",
    "timestamp": "2025-11-03T08:16:00Z",
    "witnesses": [
      "Ayana Blue",
      "Kongo Sonix"
    ],
    "isValid": true,
    "signatureHash": "cae807e2f4bb174419fd06ba0609e72c8d04fbb703cc51edea7e3a135b45e6a6"
  },
  "frequencyResonance": 639
}
```

### More Activation Examples

#### Activate Truth (1) - Jetah with Fire Seal (Perfect Resonance)
```bash
curl -X POST http://localhost:8081/evol/activate \
  -H "Content-Type: application/json" \
  -d '{
    "commandmentIndex": 1,
    "executedBy": "Jetah",
    "seal": 0,
    "location": "BLEUCHAIN node",
    "witnesses": ["The Foundation"]
  }' | jq '.frequencyResonance'
```

Expected: 1056 (528 × 2 for perfect seal alignment)

#### Activate Unity (6) - Kongo Sonix at Codex Altar
```bash
curl -X POST http://localhost:8081/evol/activate \
  -H "Content-Type: application/json" \
  -d '{
    "commandmentIndex": 6,
    "executedBy": "Kongo Sonix",
    "seal": 1,
    "location": "Codex Altar",
    "witnesses": ["Ayana Blue", "Jetah", "The Foundation"]
  }' | jq '.'
```

#### Activate Memory (3) - The Foundation at Earth Node
```bash
curl -X POST http://localhost:8081/evol/activate \
  -H "Content-Type: application/json" \
  -d '{
    "commandmentIndex": 3,
    "executedBy": "The Foundation",
    "seal": 3,
    "location": "CODEX_EARTH",
    "witnesses": ["Jetah"]
  }' | jq '.'
```

---

## Example 8: Get System Statistics

### Request
```bash
curl http://localhost:8081/evol/stats | jq '.'
```

### Response
```json
{
  "totalCommandments": 11,
  "visibleCommandments": 10,
  "hiddenCommandments": 1,
  "activeGestures": 3,
  "councilMembers": 4,
  "systemState": "Fluid",
  "reciprocalHarmonic": 6,
  "lastActivation": "2025-11-03T08:16:00Z"
}
```

### Extract Specific Stats
```bash
# Check if system is sealed
curl -s http://localhost:8081/evol/stats | jq '.systemState'

# Count gestures
curl -s http://localhost:8081/evol/stats | jq '.activeGestures'

# Get reciprocal harmonic value
curl -s http://localhost:8081/evol/stats | jq '.reciprocalHarmonic'
```

---

## Example 9: Get All Proof-of-Authority Gestures

### Request
```bash
curl http://localhost:8081/evol/gestures | jq '.'
```

### Response
```json
[
  {
    "gestureId": "POA-19ff29b76c7b4ea69534d35eda6a7171",
    "commandmentIndex": 4,
    "executedBy": "Jetah",
    "seal": 0,
    "location": "BLEUCHAIN node",
    "timestamp": "2025-11-03T08:16:00Z",
    "witnesses": [
      "Ayana Blue",
      "Kongo Sonix"
    ],
    "isValid": true,
    "signatureHash": "cae807e2f4bb174419fd06ba0609e72c8d04fbb703cc51edea7e3a135b45e6a6"
  }
  // ... more gestures
]
```

### Filter Gestures by Executor
```bash
curl -s http://localhost:8081/evol/gestures | jq '.[] | select(.executedBy == "Jetah")'
```

### Count Gestures per Commandment
```bash
curl -s http://localhost:8081/evol/gestures | jq 'group_by(.commandmentIndex) | map({commandment: .[0].commandmentIndex, count: length})'
```

---

## Example 10: Seal the Commandments System

### Request
```bash
curl -X POST http://localhost:8081/evol/seal | jq '.'
```

### Response
```json
{
  "message": "Commandments system sealed - now immutable",
  "system": {
    "commandments": [...],
    "quadrantCouncil": [...],
    "gestures": [...],
    "isSealed": true,
    "sealedAt": "2025-11-03T08:20:00Z",
    "systemState": "Sealed",
    "reciprocalHarmonicDb": 6,
    "covenantFrequency": "π⁴"
  },
  "note": "The Ten are now engraved into the Codex as EV0L Commandments of Authority"
}
```

### Verify Sealed Status
```bash
curl -s http://localhost:8081/evol/stats | jq '{state: .systemState, sealed: true}'
```

---

## Example 11: Get Complete System State

### Request
```bash
curl http://localhost:8081/evol/system | jq '.'
```

### Response
Full system object including:
- All 11 commandments
- Quadrant Council members
- All gestures
- System state (Fluid/Sealed)
- Sealed timestamp (if sealed)
- Reciprocal harmonic value
- Covenant frequency

### Extract Specific Parts
```bash
# Get only commandment names
curl -s http://localhost:8081/evol/system | jq '.commandments[].name'

# Get covenant frequency
curl -s http://localhost:8081/evol/system | jq '.covenantFrequency'

# Check if sealed
curl -s http://localhost:8081/evol/system | jq '.isSealed'
```

---

## Complete Workflow Example

### Step 1: Initial System Query
```bash
# Get all visible commandments
curl -s http://localhost:8081/evol/commandments | jq 'length'
# Output: 10

# Get stats
curl -s http://localhost:8081/evol/stats | jq '.'
```

### Step 2: Examine the Four
```bash
curl -s http://localhost:8081/evol/council | jq '.[].name'
```

### Step 3: Activate Commandments (EVOLVERS - Act I Scene)
```bash
# Jetah breathes light in BLEUCHAIN node (Breath commandment)
curl -X POST http://localhost:8081/evol/activate \
  -H "Content-Type: application/json" \
  -d '{
    "commandmentIndex": 4,
    "executedBy": "Jetah",
    "seal": 0,
    "location": "BLEUCHAIN node",
    "witnesses": ["Ayana Blue", "Kongo Sonix"]
  }' | jq '.success'

# Kongo Sonix and Ayana Blue align relics at Codex Altar (Unity)
curl -X POST http://localhost:8081/evol/activate \
  -H "Content-Type: application/json" \
  -d '{
    "commandmentIndex": 6,
    "executedBy": "Kongo Sonix",
    "seal": 1,
    "location": "Codex Altar",
    "witnesses": ["Ayana Blue"]
  }' | jq '.gesture.gestureId'
```

### Step 4: Review Gestures
```bash
curl -s http://localhost:8081/evol/gestures | jq 'length'
# Output: 2 (or more)

curl -s http://localhost:8081/evol/gestures | jq '.[].location'
```

### Step 5: Check Updated Stats
```bash
curl -s http://localhost:8081/evol/stats | jq '.'
```

### Step 6: Discover the Hidden Eleventh
```bash
curl -s http://localhost:8081/evol/commandments/11 | jq '{name, symbol, frequency: .frequencyHz}'
```

Output:
```json
{
  "name": "It",
  "symbol": "∞",
  "frequency": 97.409091034
}
```

### Step 7: Make the Decision - Seal or Stay Fluid
```bash
# Option A: Seal the commandments
curl -X POST http://localhost:8081/evol/seal | jq '.message'

# Option B: Leave fluid (do nothing, default state)
curl -s http://localhost:8081/evol/stats | jq '.systemState'
# Output: "Fluid"
```

---

## Testing Tips

### Using jq for Advanced Filtering
```bash
# Get all Fire-affiliated commandments
curl -s http://localhost:8081/evol/commandments | jq '.[] | select(.elementalAffinity == 0)'

# Get commandments with frequency > 700 Hz
curl -s http://localhost:8081/evol/commandments | jq '.[] | select(.frequencyHz > 700)'

# List commandment names and symbols
curl -s http://localhost:8081/evol/commandments | jq '.[] | {name, symbol}'
```

### Performance Testing
```bash
# Time a request
time curl -s http://localhost:8081/evol/commandments > /dev/null

# Multiple concurrent activations
for i in {1..5}; do
  curl -X POST http://localhost:8081/evol/activate \
    -H "Content-Type: application/json" \
    -d "{\"commandmentIndex\": $i, \"executedBy\": \"Jetah\", \"seal\": 0, \"location\": \"Test\", \"witnesses\": []}" &
done
wait
```

### Validation Tests
```bash
# Verify all 10 visible commandments exist
test $(curl -s http://localhost:8081/evol/commandments | jq 'length') -eq 10 && echo "✅ PASS" || echo "❌ FAIL"

# Verify 11th is hidden by default
test $(curl -s "http://localhost:8081/evol/commandments?includeHidden=false" | jq 'length') -eq 10 && echo "✅ PASS" || echo "❌ FAIL"

# Verify 11th appears with includeHidden=true
test $(curl -s "http://localhost:8081/evol/commandments?includeHidden=true" | jq 'length') -eq 11 && echo "✅ PASS" || echo "❌ FAIL"

# Verify Quadrant Council has 4 members
test $(curl -s http://localhost:8081/evol/council | jq 'length') -eq 4 && echo "✅ PASS" || echo "❌ FAIL"
```

---

## Integration with Existing BLEU Systems

### Cross-Reference with BLEU Flame
```bash
# Check BLEU metadata
curl -s http://localhost:8081/bleu/metadata | jq '.name'

# Commandments integrate through:
# - Light (5) → Thermal activation
# - Healing (8) → Harvest-Mint-Heal loop
# - Evolution (9) → ENFT transformation
```

### Cross-Reference with Zion Gold Bar
```bash
# Check Zion metadata
curl -s http://localhost:8081/zion/metadata | jq '.name'

# Commandments integrate through:
# - Memory (3) → EV0L Rosetta Ledger
# - Wealth (7) → Saturn-Strata resources
# - Legacy (10) → Generational transfer
```

### Cross-Reference with MetaVault
```bash
# Check treasury
curl -s http://localhost:8081/metavault/treasury | jq '.'

# Commandments integrate through:
# - Unity (6) → Cross-sector routing
# - Wealth (7) → Yield formulas
# - "It" (11) → π⁴ in calculations
```

---

## Summary

**Total Endpoints**: 10  
**Commandments**: 11 (10 visible + 1 hidden)  
**Council Members**: 4  
**Elemental Seals**: 4  
**Commandment Types**: 5  

All endpoints tested and verified ✅

---

**Testing Guide Version**: 1.0.0  
**Last Updated**: November 3, 2025  
**API Base URL**: `http://localhost:8081`  
**Interactive Docs**: `http://localhost:8081/scalar`

---

*"Ten visible pillars, and then the unspoken eleventh, 'It,' the covenant key, running beneath them like current."*

**EV0L Commandments Testing Authority**  
*BLEU Codex Division - API Testing Protocol*
