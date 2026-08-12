# Dreamine.Gem300.Abstractions

GEM300 메모리 내 도메인 경계를 위한 공급자 중립 계약, 불변 모델 및 상태 Enum입니다.

[➡️ English Version](README.md)

## 범위와 증거

| 기능 | 상태 | 증거 경계 |
|---|---|---|
| GEM300 도메인 계약과 모델 | `PASS` | 모델·검증·Assembly Boundary 집중 테스트 |
| E39.1/E40.1/E87.1/E90.1/E94.1 표준 wire 계약 | `BLOCKED_STANDARD` | 필요한 mapping 원문을 로컬에서 확보하지 못함 |
| E116/E116.1 Equipment Performance 계약 | `BLOCKED_STANDARD` | 두 규범 원문이 모두 없어 placeholder API도 공개하지 않음 |
| 외부 상호운용 및 현장 증거 | `NOT_RUN` | 독립 counterpart 또는 실장비 검증을 수행하지 않음 |

`PASS`는 선언한 프로세스 내 도메인 경계에만 적용됩니다. 현재판 적합성, 인증,
SECS-II mapping 또는 벤더 상호운용을 뜻하지 않습니다.

## 포함한 계약

- Object, Carrier/Load Port, Substrate, Process Job, Control Job 및 Event Journal 경계
- 컬렉션 입력을 복사하는 불변 정의와 Snapshot
- 애플리케이션이 명시하는 Carrier Slot↔Substrate 연결(통합 메타데이터이며 wire 모델이 아님)
- 프로세스 내 Event Identity와 제한 용량 보존/Publisher Health 모델
- Process Job 생성 시 Recipe ID를 검증할 수 있는 보존 Process Program Snapshot 모델

이 패키지는 `Dreamine.Gem.Abstractions`와 `Dreamine.Secs.Abstractions`만
참조합니다. 구체 GEM/GEM300 공급자, Transport, 메시지 번호, ACK 값 또는 Service
Error 값은 포함하지 않습니다.

기존 Interface와 Constructor는 유지했습니다. Hardening 공개 표면은 additive이며,
정의되지 않은 Enum 값과 불일치한 명시적 Slot 계획은 더 이른 시점에 거부합니다.
[API 검토](docs/API_REVIEW.md)와 생성된 [공개 API 목록](docs/PUBLIC_API.md)을
확인하십시오.

## 라이선스

MIT.
